using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ClickerModel _clikerModel;
    private LevelModel _levelModel;
    private UpgradesModel _upgradesModel;
    
    public ClickerModel ClikerModel => _clikerModel;
    public LevelModel LevelModel => _levelModel;
    public UpgradesModel UpgradesModel => _upgradesModel;
    
    private void Awake()
    {
        _clikerModel = new ClickerModel();
        _levelModel = new LevelModel();
        _upgradesModel = new UpgradesModel();
    }
}