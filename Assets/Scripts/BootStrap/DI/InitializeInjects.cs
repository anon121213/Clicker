using BootStrap.AssetsLoader.Services;
using BootStrap.Bootstap;
using BootStrap.Data.DataServices;
using BootStrap.Data.StaticData;
using BootStrap.FSM;
using BootStrap.FSM.States;
using BootStrap.GameFabric;
using ClickSystem;
using LevelSystem;
using PopUp.Factory;
using PopUp.Main;
using PopUp.Pool;
using UnityEngine;
using UpgradeSystem;
using UpgradeSystem.Models;
using UpgradeSystem.Services.Money;
using UpgradeSystem.Services.Xp;
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
            RegisterPresenters(builder);
            RegisterServices(builder);
            RegisterModels(builder);
            RegisterPopUp(builder);
            
            builder.RegisterEntryPoint<GameBootstrapper>();
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<IGameFactory, GameFactory>(Lifetime.Singleton);
            
            builder.Register<ILoadAssetService, LoadAssetServiceService>(Lifetime.Singleton);

            builder.Register<IPersistentProgressService, PersistentProgressServiceService>(Lifetime.Singleton);

            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);

            builder.Register<IProgressUsersService, ProgressUsersService>(Lifetime.Singleton);

            builder.Register<IDisposeService, DisposeService>(Lifetime.Singleton);

            builder.Register<IClickService, ClickService>(Lifetime.Singleton);

            builder.Register<IPopUpCreateService, PopUpCreateService>(Lifetime.Singleton);

            builder.Register<IUpgradeClickPriceService, UpgradeClickPriceService>(Lifetime.Singleton);

            builder.Register<IUpgradeClickXpService, UpgradeClickXpService>(Lifetime.Singleton);

            builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);

            builder.Register<ILoadDefaultProgress, LoadDefaultProgress>(Lifetime.Singleton);
        }

        private void RegisterPresenters(IContainerBuilder builder)
        {
            builder.Register<ClickerPresenter>(Lifetime.Singleton);
            
            builder.Register<LevelPresenter>(Lifetime.Singleton);
            
            builder.Register<UpgradesPresenter>(Lifetime.Singleton);
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<SceneLoader>(Lifetime.Singleton);

            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.Register<BootstrapState>(Lifetime.Singleton);

            builder.Register<LoadLevelState>(Lifetime.Singleton);

            builder.Register<LoadProgressState>(Lifetime.Singleton);
        }

        private void RegisterModels(IContainerBuilder builder)
        {
            builder.Register<IClickerModel, ClickerModel>(Lifetime.Singleton);
            
            builder.Register<ILevelModel, LevelModel>(Lifetime.Singleton);
            
            builder.Register<IUpgradesMoneyModel, UpgradesMoneyModel>(Lifetime.Singleton);
            
            builder.Register<ILevelUpgradesModel, LevelUpgradesModel>(Lifetime.Singleton);
        }

        private void RegisterPopUp(IContainerBuilder builder)
        {
            builder.Register<PopUpPool>(Lifetime.Singleton);
            
            builder.Register<IPopUpFactory, PopUpFactory>(Lifetime.Singleton);
        }
    }
}