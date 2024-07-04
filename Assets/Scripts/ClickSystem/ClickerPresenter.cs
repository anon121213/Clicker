using UnityEngine;
using VContainer;

public class ClickerPresenter : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    
    private GameManager _gameManager;
    private ClickerModel _clickModel;
    private UpgradesModel _upgradesModel;
    private IClickerView _view;
    private PlaySFX _playSfx;
    
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
        _playSfx = PlaySFX.instance;
    }

    public void OnClick()
    {
        _playSfx.PlayMusic(_clickSound);
        _clickModel.IncrementMoneyCount(_upgradesModel.GetClickPrice());
        _view.UpdateClickCount(_clickModel.GetMoneyCount());
        
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var clickPosition = touch.position;
            _view.SpawnClickPopUp(clickPosition);
        }
    }
}