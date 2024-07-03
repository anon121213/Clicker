using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ClickerModel _clikerModel;
    private LevelModel _levelModel;

    public ClickerModel clikerModel => _clikerModel;
    public LevelModel levelModel => _levelModel;
    
    private void Awake()
    {
        _clikerModel = new ClickerModel();
        _levelModel = new LevelModel();
    }
}