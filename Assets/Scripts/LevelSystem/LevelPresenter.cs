using System;
using UnityEngine;
using VContainer;

public class LevelPresenter: MonoBehaviour
{
    private ILevelView _levelView;
    private GameManager _gameManager;

    [Inject]
    private void Initialize(ILevelView levelView, GameManager gameManager)
    {
        _levelView = levelView;
        _gameManager = gameManager;
    }

    private void Start()
    {
        _levelView.UpdateLevel(_gameManager.clikerModel.GetClickPrice(), _gameManager.levelModel.GetClicksForNewLvL());
        _levelView.UpdateClicksForNewLvlText(_gameManager.levelModel.GetClicksForNewLvL(), _gameManager.levelModel.GetCurrentLvL());
    }

    public void OnClick()
    {
        if (_gameManager.levelModel.GetCurrentClicks() + _gameManager.clikerModel.GetClickPrice() < _gameManager.levelModel.GetClicksForNewLvL())
        {
            _gameManager.levelModel.IncrementClicks(_gameManager.clikerModel.GetClickPrice());
            _levelView.UpdateLevel(_gameManager.levelModel.GetCurrentClicks(), _gameManager.levelModel.GetClicksForNewLvL());
        }
        else
        {
            _gameManager.levelModel.IncrementLvL();
            _gameManager.levelModel.IncrementClicksForNewLvl();
            _gameManager.levelModel.DecrimentCuddentClicks();
            _levelView.UpdateLevel(_gameManager.clikerModel.GetClickPrice(), _gameManager.levelModel.GetClicksForNewLvL());
            _levelView.UpdateClicksForNewLvlText(_gameManager.levelModel.GetClicksForNewLvL(), _gameManager.levelModel.GetCurrentLvL());
        }
    }
}
