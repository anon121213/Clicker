using TMPro;
using UnityEngine;
using VContainer;

public class PopUpCountChanger: MonoBehaviour
{
    private GameManager _gameManager;
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        ChangeCount();
    }

    [Inject]
    private void Inicialize(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void ChangeCount()
    {
        //_textMeshProUGUI.text = $"+{_gameManager.UpgradesModel.GetClickPrice()}";
    }
}
