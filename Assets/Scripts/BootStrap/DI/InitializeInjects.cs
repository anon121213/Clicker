using BootStrap.GameFabric;
using BootStrap.Services;
using VContainer;
using VContainer.Unity;

namespace BootStrap.DI
{
    public class InitializeInjects : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterServices(builder);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);
            
            builder.Register<ILoadAssetService, LoadAssetServiceService>(Lifetime.Singleton);

            builder.Register<IPersistentProgressService, PersistentProgressServiceService>(Lifetime.Singleton);

            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
        }
    }
}