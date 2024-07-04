using UnityEngine;
using VContainer;

public class ClickerPresenter : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    
    private GameManager _gameManager;
    private ClickerModel _clickModel;
    private UpgradesModel _upgradesModel;
    private IClickerView _view;
    
    [Inject]
    public void Construct(IClickerView view, GameManager gameManager)
    {
        _view = view;
        _gameManager = gameManager;
    }

    private void Start()
    {
        _clickModel = _gameManager.ClikerModel;
        _upgradesModel = _gameManager.UpgradesModel;
        _view.UpdateClickCount(_clickModel.GetMoneyCount());
    }

    public void OnClick()
    {
        PlaySFX.instance.PlayMusic(_clickSound);
        _clickModel.IncrementMoneyCount(_upgradesModel.GetClickPrice());
        _view.UpdateClickCount(_clickModel.GetMoneyCount());
        
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var clickPosition = touch.position;
            _view.SpawnClickPopUp(clickPosition);
        }

        PlayerData.Instance.Money = _gameManager.ClikerModel.GetMoneyCount();
        EntryPoint.Instance._dataSaver.Save();
    }
}