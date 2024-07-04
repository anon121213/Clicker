using UnityEngine;
using VContainer;

public class UpgradesPresenter : MonoBehaviour
{
    [SerializeField] private int _upgradeCount;
    
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

    public void Upgrade()
    {
        _upgradesModel.IncrementClickPrice(_upgradeCount);
        _view.UpdateClickPrice(_upgradesModel.GetClickPrice());
    }
}