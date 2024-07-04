﻿using UnityEngine;
using VContainer;

public class UpgradesPresenter : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private int _upgradeClickPriceCount;
    [SerializeField] private int _upgradeXpCount;
    [SerializeField] private int _intrementLvlForBuyClickUpgrade = 3;
    [SerializeField] private int _intrementLvlForBuyXpClickUpgrade = 3;
    
    private GameManager _gameManager;
    private UpgradesModel _upgradesModel;
    private IUpgradesVuew _view;
    

    [Inject]
    public void Construct(IUpgradesVuew view, GameManager gameManager)
    {
        _view = view;
        _gameManager = gameManager;
    }
    
    private void Start()
    {
        _upgradesModel = _gameManager.UpgradesModel;
        _view.UpdateClickPrice(_upgradesModel.GetClickPrice());
    }

    public void UpgradeClickPrice()
    {
        if (_gameManager.UpgradesModel.LvlForUpgradeClickPrice <= _gameManager.LevelModel.GetCurrentLvL() && _gameManager.ClikerModel.GetMoneyCount() >= _price)
        {
            _upgradesModel.IncrementClickPrice(_upgradeClickPriceCount);
            _upgradeClickPriceCount = (int)Mathf.Round(_upgradeClickPriceCount * 1.5f);
            _gameManager.UpgradesModel.LvlForUpgradeClickPrice = _intrementLvlForBuyClickUpgrade;
            _gameManager.ClikerModel.DecrimentMoneyCount(_price);
            _view.UpdateClickPrice(_upgradesModel.GetClickPrice());
        }
        else
        {
            return;
        }
    }

    public void UpgradeClickXP()
    {
        if (_gameManager.UpgradesModel.LvlForUpgradeClickXpPrice <= _gameManager.LevelModel.GetCurrentLvL() && _gameManager.ClikerModel.GetMoneyCount() >= _price)
        {
            _upgradesModel.IncrementClickXpPrice(_upgradeXpCount);
            _upgradeXpCount = (int)Mathf.Round(_upgradeXpCount * 1.5f);
            _gameManager.UpgradesModel.LvlForUpgradeClickXpPrice = _intrementLvlForBuyXpClickUpgrade;
            _gameManager.ClikerModel.DecrimentMoneyCount(_price);
            _view.UpdateClickXpPrice(_upgradesModel.GetClickXpPrice());
        }
        else
        {
            return;
        }
    }
}