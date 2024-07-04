using UnityEngine;
using DG.Tweening;

public class TabSwitcher : MonoBehaviour
{
    public GameObject[] tabs; // Ваши окна
    public float duration = 0.5f; // Продолжительность анимации

    public void SwitchToTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            if (i == index)
            {
                // Анимация переключения на выбранную вкладку
                tabs[i].transform.DOLocalMoveX(0, duration).SetEase(Ease.InOutQuad);
            }
            else if (tabs[i].transform.localPosition.x != 0)
            {
                // Анимация перемещения невыбранных вкладок в сторону
                tabs[i].transform.DOLocalMoveX(i < index ? -Screen.width : Screen.width, duration).SetEase(Ease.InOutQuad);
            }
        }
    }
}