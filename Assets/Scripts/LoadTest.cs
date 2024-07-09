using BootStrap.Data;
using UnityEngine;

public class LoadTest : MonoBehaviour, ISavedProgress
{
    public PlayerProgres _progress;
    
    public void LoadProgress(PlayerProgres progres)
    {
        Debug.Log(progres.Money);
    }

    public void UpdateProgress(PlayerProgres progres)
    {
        progres.Money++;
        Debug.Log(progres.Money);
    }
}
