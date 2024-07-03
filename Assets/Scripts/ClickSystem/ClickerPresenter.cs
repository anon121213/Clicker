using UnityEngine;
using VContainer;

public class ClickerPresenter : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRectTransform;
    
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
        _view.UpdateClickCount(_model.GetClickCount());
    }

    public void OnClick()
    {
        _model.IncrementClickCount(_model.GetClickPrice());
        _view.UpdateClickCount(_model.GetClickCount());
        
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var clickPosition = touch.position;
            _view.SpawnClickPopUp(clickPosition);
        }
    }
}