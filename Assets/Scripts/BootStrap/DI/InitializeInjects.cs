using BootStrap.Assets;
using BootStrap.FSM;
using BootStrap.GameFabric;
using BootStrap.Services;
using PopUp.Pool;
using VContainer;
using VContainer.Unity;

namespace BootStrap.DI
{
    public class InitializeInjects : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);
        
            builder.Register<ILoadAsset, LoadAssetService>(Lifetime.Singleton);

            builder.Register<IPersistentProgressService, PersistentProgressServiceService>(Lifetime.Singleton);

            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
        
            builder.Register<SceneLoader>(Lifetime.Singleton);
        
            builder.Register<PopUpPool>(Lifetime.Singleton);
        }
    }
}