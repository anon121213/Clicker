using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class EntryPoint : MonoBehaviour, IInitializable, IDisposable
{
    public static EntryPoint Instance { get; private set; }

    public PlayerData PlayerData { get; private set; }
    private IDataSaver _dataSaver;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }

    public EntryPoint(IDataSaver dataSaver)
    {
        _dataSaver = dataSaver;
        Instance = this;
    }
    
    public void Initialize()
    {
        PlayerData = _dataSaver.Load();
    }

    public void Dispose()
    {
        _dataSaver.Save();
    }
}