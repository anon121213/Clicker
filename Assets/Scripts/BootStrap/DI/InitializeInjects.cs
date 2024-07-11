using BootStrap.AssetsLoader.Services;
using BootStrap.Bootstap;
using BootStrap.Data.DataService;
using BootStrap.FSM;
using BootStrap.FSM.States;
using BootStrap.GameFabric;
using ClickSystem;
using LevelSystem;
using UnityEngine;
using UpgradeSystem;
using VContainer;
using VContainer.Unity;

namespace BootStrap.DI
{
    public class InitializeInjects : LifetimeScope
    {
        [SerializeField] private ClickerView _clickerView;
        [SerializeField] private LevelView _levelView;
        [SerializeField] private UpgradesView _upgradesView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStates(builder);
            RegisterServices(builder);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);
            
            builder.Register<ILoadAssetService, LoadAssetServiceService>(Lifetime.Singleton);

            builder.Register<IPersistentProgressService, PersistentProgressServiceService>(Lifetime.Singleton);

            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);

            builder.Register<IProgressUsersService, ProgressUsersService>(Lifetime.Singleton);
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