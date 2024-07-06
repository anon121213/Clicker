using BootStrap;
using PopUp.Pool;
using VContainer;
using VContainer.Unity;

public class InitializeInjects : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameStateMachine>(Lifetime.Singleton);
        builder.Register<SceneLoader>(Lifetime.Singleton);
        builder.Register<PopUpPool>(Lifetime.Singleton);
    }
}