using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CompositionRoot : LifetimeScope
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ClickerView _clickerView;
    [SerializeField] private LevelView _levelView;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance<IClickerView>(_clickerView);
        builder.RegisterInstance<ILevelView>(_levelView);
        builder.RegisterInstance(_gameManager);
    }
}
