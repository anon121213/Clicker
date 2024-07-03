using UnityEngine;

public interface IClickerView
{
    void UpdateClickCount(int count);
    void UpdateClickPrice(int count);
    void SpawnClickPopUp(Vector2 position);
}