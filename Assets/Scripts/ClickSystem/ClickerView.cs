using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClickSystem
{
    public class ClickerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _Money;
        [SerializeField] private TextMeshProUGUI _clickPrice;
        
        public AudioClip _clickSound;
        public Transform _popUpRoot;
        public Button _clickButton;

        public void UpdateClickCount(int count) =>
            _Money.text = $"Money: {count}";
    }
}