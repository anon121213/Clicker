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
        _levelView.UpdateLevel(_gameManager.LevelModel.GetCurrentClicks(), _gameManager.LevelModel.GetClicksForNewLvL());
        _levelView.UpdateClicksForNewLvlText(_gameManager.LevelModel.GetClicksForNewLvL(), _gameManager.LevelModel.GetCurrentLvL());
    }

    public void OnClick()
    {
        if (_gameManager.LevelModel.GetCurrentClicks() + _gameManager.UpgradesModel.GetClickPrice() < _gameManager.LevelModel.GetClicksForNewLvL())
        {
            _gameManager.LevelModel.IncrementClicks(_gameManager.UpgradesModel.GetClickXpPrice());
            _levelView.UpdateLevel(_gameManager.LevelModel.GetCurrentClicks(), _gameManager.LevelModel.GetClicksForNewLvL());
        }
        else
        {
            _gameManager.LevelModel.IncrementLvL();
            _gameManager.LevelModel.IncrementClicksForNewLvl();
            _gameManager.LevelModel.DecrimentCuddentClicks();
            _levelView.UpdateLevel(_gameManager.UpgradesModel.GetClickXpPrice(), _gameManager.LevelModel.GetClicksForNewLvL());
            _levelView.UpdateClicksForNewLvlText(_gameManager.LevelModel.GetClicksForNewLvL(), _gameManager.LevelModel.GetCurrentLvL());
        }
    }
}
