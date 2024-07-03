using UnityEngine;
using VContainer;

public class UpgradesPresenter : MonoBehaviour
{
    [SerializeField] private int _upgradeCount;
    
    private GameManager _gameManager;
    private ClickerModel _model;
    private IClickerView _view;

    [Inject]
    public void Construct(IClickerView view, GameManager gameManager)
    {
        _view = view;
        _gameManager = gameManager;
    }
    
    private void Start()
    {
        _model = _gameManager.clikerModel;
        _view.UpdateClickPrice(_model.GetClickPrice());
    }

    public void Upgrade()
    {
        _model.IncrementClickPrice(_upgradeCount);
        _view.UpdateClickPrice(_model.GetClickPrice());
    }
}