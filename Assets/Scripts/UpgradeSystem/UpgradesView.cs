using UnityEngine;
using TMPro;

public class UpgradesView: MonoBehaviour, IUpgradesVuew
{
    [SerializeField] private TextMeshProUGUI _clickPrice;
    
    public void UpdateClickPrice(int count)
    {
        _clickPrice.text = $"Click price: {count}";
    }
}
