using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<PlayerPrefsDataSaver>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterEntryPoint<EntryPoint>();
    }
}