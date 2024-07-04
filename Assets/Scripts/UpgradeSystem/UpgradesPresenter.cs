using UnityEngine;
using VContainer;

public class UpgradesPresenter : MonoBehaviour
{
    [SerializeField] private AudioClip _errorSound;
    [SerializeField] private AudioClip _buySound;
    
    private GameManager _gameManager;
    private UpgradesModel _upgradesModel;
    private IUpgradesView _view;
    private IClickerView _clickerView;

    [Inject]
    public void Construct(IUpgradesView view, IClickerView clickerView, GameManager gameManager)
    {
        _view = view;
        _clickerView = clickerView;
        _gameManager = gameManager;
    }
    
    private void Start()
    {
        _upgradesModel = _gameManager.UpgradesModel;
        _view.UpdateClickPrice(_upgradesModel.GetClickPrice());
        _clickerView.UpdateClickCount(_gameManager.ClikerModel.GetMoneyCount());
        _view.UpdateUpgradeClickMoney(_upgradesModel.UpgradePriceForUpgradeMoneyClick, _upgradesModel.UpgradeClickPrice);
        _view.UpdateUpgradeClickXp(_upgradesModel.UpgradePriceForUpgradeXpClick, _upgradesModel.UpgradeClickXpPrice);
        _view.UpdateClickXpPrice(_upgradesModel.GetClickXpPrice());
        _view.UpdateNeedLvlForUpgradeMoneyClick(_gameManager.UpgradesModel.GetLvlForUpgradeClickPrice());
        _view.UpdateNeedLvlForUpgradeXpClick(_gameManager.UpgradesModel.GetLvlForUpgradeXpClickPrice());
    }

    public void UpgradeClickPrice()
    {
        if (_gameManager.UpgradesModel.GetLvlForUpgradeClickPrice() <= _gameManager.LevelModel.GetCurrentLvL() && _gameManager.ClikerModel.GetMoneyCount() >= _gameManager.UpgradesModel.UpgradePriceForUpgradeMoneyClick)
        {
            PlaySFX.instance.PlayMusic(_buySound);
            
            _upgradesModel.IncrementClickPrice(_upgradesModel.UpgradeClickPrice);
            _upgradesModel.UpgradeClickPrice = (int)Mathf.Round(_upgradesModel.UpgradeClickPrice * 1.5f);
            
            _gameManager.ClikerModel.DecrimentMoneyCount(_gameManager.UpgradesModel.UpgradePriceForUpgradeMoneyClick);
            _gameManager.UpgradesModel.UpgradePriceForUpgradeMoneyClick *= 2; 
            _gameManager.UpgradesModel.IncrementLvlForUpgradeClick(1);
            
            _view.UpdateClickPrice(_upgradesModel.GetClickPrice());
            _clickerView.UpdateClickCount(_gameManager.ClikerModel.GetMoneyCount());
            _view.UpdateUpgradeClickMoney(_upgradesModel.UpgradePriceForUpgradeMoneyClick, _upgradesModel.UpgradeClickPrice);
            _view.UpdateNeedLvlForUpgradeMoneyClick(_gameManager.UpgradesModel.GetLvlForUpgradeClickPrice());
            
            SaveDataClick();
        }
        else
        {
            PlaySFX.instance.PlayMusic(_errorSound);
        }
    }

    public void UpgradeClickXP()
    {
        if (_gameManager.UpgradesModel.GetLvlForUpgradeXpClickPrice() <= _gameManager.LevelModel.GetCurrentLvL() && _gameManager.ClikerModel.GetMoneyCount() >= _gameManager.UpgradesModel.UpgradePriceForUpgradeXpClick)
        {
            PlaySFX.instance.PlayMusic(_buySound);
            
            _upgradesModel.IncrementClickXpPrice(_upgradesModel.UpgradeClickXpPrice);
            _upgradesModel.UpgradeClickXpPrice = (int)Mathf.Round(_upgradesModel.UpgradeClickXpPrice * 1.5f);
            
            _gameManager.ClikerModel.DecrimentMoneyCount(_gameManager.UpgradesModel.UpgradePriceForUpgradeXpClick);
            _gameManager.UpgradesModel.UpgradePriceForUpgradeXpClick *= 2; 
            _gameManager.UpgradesModel.IncrementLvlForUpgradeXpClick(1);
            
            _view.UpdateClickXpPrice(_upgradesModel.GetClickXpPrice());
            _clickerView.UpdateClickCount(_gameManager.ClikerModel.GetMoneyCount());
            _view.UpdateUpgradeClickXp(_upgradesModel.UpgradePriceForUpgradeXpClick, _upgradesModel.UpgradeClickXpPrice);
            _view.UpdateNeedLvlForUpgradeXpClick(_gameManager.UpgradesModel.GetLvlForUpgradeXpClickPrice());
            
            SaveDataXpClick();
        }
        else
        {
            PlaySFX.instance.PlayMusic(_errorSound);
        }
    }

    private void SaveDataClick()
    {
        PlayerData.Instance.ClickPrice = _gameManager.UpgradesModel.GetClickPrice();
        PlayerData.Instance.LvlForUpgradeClickPrice = _gameManager.UpgradesModel.GetLvlForUpgradeClickPrice();
        PlayerData.Instance.UpgradeClickPriceCount = _gameManager.UpgradesModel.UpgradeClickPrice;
        PlayerData.Instance.PriceUpgradeMoneyClickPrice = _gameManager.UpgradesModel.UpgradePriceForUpgradeMoneyClick;
    }

    private void SaveDataXpClick()
    {
        PlayerData.Instance.ClickXpPrice = _gameManager.UpgradesModel.GetClickXpPrice();
        PlayerData.Instance.LvlForUpgradeClickXpPrice = _gameManager.UpgradesModel.GetLvlForUpgradeXpClickPrice();
        PlayerData.Instance.UpgradeClickXpCount = _gameManager.UpgradesModel.UpgradeClickXpPrice;
        PlayerData.Instance.PriceUpgradeXpClickPrice = _gameManager.UpgradesModel.UpgradePriceForUpgradeXpClick;
    }
}