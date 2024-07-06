using PopUp.Main;
using PopUp.Pool;
using TMPro;
using UnityEngine;
using VContainer;

public class ClickerView : MonoBehaviour, IClickerView 
{
    [SerializeField] private TextMeshProUGUI _clickCountText;
    [SerializeField] private TextMeshProUGUI _clickPrice;
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
}