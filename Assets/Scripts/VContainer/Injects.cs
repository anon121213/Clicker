using ClickSystem;
using LevelSystem;
using ModelsFactory;
using PopUp.Factory;
using PopUp.Pool;
using UnityEngine;
using UpgradeSystem;
using VContainer.Unity;

namespace VContainer
{
    public class Injects : LifetimeScope
    {
        [SerializeField] private ClickerView _clickerView;
        [SerializeField] private LevelView _levelView;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterModels(builder);
            RegisterViews(builder);
            RegisterPopUp(builder);
            RegisterFactory(builder);
        }

        private void RegisterFactory(IContainerBuilder builder)
        {
            builder.Register<IModelsFactory, ModelsFactory.ModelsFactory>(Lifetime.Singleton);
        }
        
        //will be delite
        private void RegisterModels(IContainerBuilder builder)
        {
            builder.Register<ClickerModel>(Lifetime.Singleton);
            builder.Register<LevelModel>(Lifetime.Singleton);
            builder.Register<UpgradesModel>(Lifetime.Singleton);
        }

        private void RegisterViews(IContainerBuilder builder)
        {
            builder.RegisterInstance<LevelView>(_levelView);
            builder.Register<UpgradesView>(Lifetime.Singleton);
            builder.RegisterInstance<ClickerView>(_clickerView);
        }

        private void RegisterPopUp(IContainerBuilder builder)
        {
            builder.Register<PopUpPool>(Lifetime.Singleton);
            builder.Register<IPopUpFactory, PopUpFactory>(Lifetime.Singleton);
        }
    }
}
