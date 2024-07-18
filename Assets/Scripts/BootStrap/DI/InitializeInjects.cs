using BootStrap.AssetsLoader.Services;
using BootStrap.Bootstap;
using BootStrap.Data.DataServices;
using BootStrap.Data.StaticData;
using BootStrap.FSM;
using BootStrap.FSM.States;
using BootStrap.GameFabric;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace BootStrap.DI
{
    public class InitializeInjects : LifetimeScope
    {
        [SerializeField] private AllData _allData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStates(builder);
            RegisterServices(builder);
            
            builder.RegisterEntryPoint<GameBootstrapper>();
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);
            
            builder.Register<ILoadAssetService, LoadAssetServiceService>(Lifetime.Singleton);

            builder.Register<IPersistentProgressService, PersistentProgressServiceService>(Lifetime.Singleton);

            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);

            builder.Register<IProgressUsersService, ProgressUsersService>(Lifetime.Singleton);

            builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);

            builder.Register<ILoadDefaultProgress, LoadDefaultProgress>(Lifetime.Singleton);
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<SceneLoader>(Lifetime.Singleton);

            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.Register<BootstrapState>(Lifetime.Singleton);

            builder.Register<LoadLevelState>(Lifetime.Singleton);

            builder.Register<LoadProgressState>(Lifetime.Singleton);
        }
    }
}