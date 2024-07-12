using BootStrap.AssetsLoader.Services;
using BootStrap.Bootstap;
using BootStrap.Data.DataService;
using BootStrap.FSM;
using BootStrap.FSM.States;
using BootStrap.GameFabric;
using ClickSystem;
using LevelSystem;
using ModelsFactory;
using PopUp.Factory;
using PopUp.Pool;
using UpgradeSystem;
using VContainer;
using VContainer.Unity;

namespace BootStrap.DI
{
    public class InitializeInjects : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStates(builder);
            RegisterServices(builder);
            RegisterModels(builder);
            RegisterPopUp(builder);
            RegisterFactory(builder);
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
        
        private void RegisterFactory(IContainerBuilder builder)
        {
            builder.Register<IPresentorsFactory, PresentorsFactory>(Lifetime.Singleton);
        }
        
        private void RegisterModels(IContainerBuilder builder)
        {
            builder.Register<ClickerModel>(Lifetime.Singleton);
            builder.Register<LevelModel>(Lifetime.Singleton);
            builder.Register<UpgradesMoneyModel>(Lifetime.Singleton);
            builder.Register<LevelUpgradesModel>(Lifetime.Singleton);
        }

        private void RegisterPopUp(IContainerBuilder builder)
        {
            builder.Register<PopUpPool>(Lifetime.Singleton);
            builder.Register<IPopUpFactory, PopUpFactory>(Lifetime.Singleton);
        }
    }
}