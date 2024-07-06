using PopUp.Factory;
using PopUp.Main;
using Unity.Mathematics;
using UnityEngine;
using VContainer;

public class ClickerPresenter : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private Transform _popUpRoot;
    
    private GameManager _gameManager;
    private ClickerModel _clickModel;
    private UpgradesModel _upgradesModel;
    private IClickerView _view;
    private IPopUpFactory _popUpFactoryImplementation;
    private IPopUpFactory _popUpFactory;

    [Inject]
    public void Construct(IClickerView view, GameManager gameManager, IPopUpFactory popUpFactory)
    {
        _view = view;
        _gameManager = gameManager;
        _popUpFactory = popUpFactory;
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
            PopUpCountChanger popUp = _popUpFactory.Create(clickPosition, _popUpRoot, quaternion.identity);
            popUp.Enable();
        }
    }

    public void Create(Vector2 position, Transform root, Quaternion rotation)
    {
        _popUpFactoryImplementation.Create(position, root, rotation);
    }
}