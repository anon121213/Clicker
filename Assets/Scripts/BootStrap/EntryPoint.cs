using System;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class EntryPoint : IInitializable, IDisposable
{
    public static EntryPoint Instance { get; private set; }

    public PlayerData PlayerData { get; private set; }
    private readonly IDataSaver dataSaver;

    public EntryPoint(IDataSaver dataSaver)
    {
        this.dataSaver = dataSaver;
        Instance = this;
    }

    public void Initialize()
    {
        PlayerData = dataSaver.Load();
        
        SceneManager.LoadScene(1);
    }

    public void Dispose()
    {
        dataSaver.Save(PlayerData);
    }
}