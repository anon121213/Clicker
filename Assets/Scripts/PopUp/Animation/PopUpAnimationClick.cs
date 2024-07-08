using DG.Tweening;
using TMPro;
using UnityEngine;

namespace PopUp.Animation
{
    public class PopUpAnimationClick : MonoBehaviour
    {
        [SerializeField] private float moveDistance = 30f;
        [SerializeField] private float duration = 0.5f;

        private TextMeshProUGUI _text;
        private RectTransform _rectTransform;
    
        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _rectTransform = GetComponent<RectTransform>();
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _text.DOFade(0, duration);
        }

        private void Update()
        {
            _text.raycastTarget = false;
            _rectTransform.DOBlendableMoveBy(new Vector3(0, moveDistance, 0), duration);
        }
    }
}
