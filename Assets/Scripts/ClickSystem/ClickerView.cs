using PopUp.Pool;
using TMPro;
using UnityEngine;
using VContainer;

public class ClickerView : MonoBehaviour, IClickerView 
{
    [SerializeField] private TextMeshProUGUI _clickCountText;
    [SerializeField] private TextMeshProUGUI _clickPrice;
    [SerializeField] private PopUpCountChanger _prefab;
    [SerializeField] private Transform _perentTransform;
    
    private PopUpPool _popUpPool;
    
    [Inject]
    private void Inject(PopUpPool popUpPool)
    {
        _popUpPool = popUpPool;
    }
    
    public void UpdateClickCount(int count)
    {
        _clickCountText.text = $"Money: {count}";
    }

    public void SpawnClickPopUp(Vector2 position)
    {
        _popUpPool.prefab = _prefab;
        _popUpPool.position = position;
        _popUpPool.perentTransform = _perentTransform;
        _popUpPool.Click();
    }

}