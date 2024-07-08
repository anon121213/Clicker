using DG.Tweening;
using UnityEngine;

namespace WindowManager
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _windows; 
        [SerializeField] private RectTransform[] tabs;
        [SerializeField] private float duration = 0.5f;
    
        public void SelectTab(int index)
        {
            if (index < 0 || index >= tabs.Length)
            {
                Debug.LogError("Index out of range");
                return;
            }

            Vector2 targetPosition = tabs[index].anchoredPosition;
            _windows.transform.DOLocalMoveX(targetPosition.x, duration);
        }
    }
}