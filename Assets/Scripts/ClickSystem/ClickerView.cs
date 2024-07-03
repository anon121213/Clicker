using TMPro;
using UnityEngine;

public class ClickerView : MonoBehaviour, IClickerView
{
    [SerializeField] private TextMeshProUGUI _clickCountText;
    [SerializeField] private TextMeshProUGUI _clickPrice;
    [SerializeField] private ClickPopUpPool _clickPopUpPool;
    
    public void UpdateClickCount(int count)
    {
        _clickCountText.text = $"Money: {count}";
    }

    public void UpdateClickPrice(int count)
    {
        _clickPrice.text = $"Click price: {count}";
    }

    public void SpawnClickPopUp(Vector2 position)
    {
        _clickPopUpPool.GetObject(position);
    }
}