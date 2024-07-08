using BootStrap.Assets;
using BootStrap.FSM;
using BootStrap.GameFabric;
using PopUp.Pool;
using VContainer;
using VContainer.Unity;

namespace BootStrap
{
    public class InitializeInjects : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        
            builder.Register<IGameFabric, GameFabric.GameFabric>(Lifetime.Singleton);
        
            builder.Register<ILoadAsset, LoadAssetService>(Lifetime.Singleton);
        
            builder.Register<SceneLoader>(Lifetime.Singleton);
        
            builder.Register<PopUpPool>(Lifetime.Singleton);
        }
    }
}