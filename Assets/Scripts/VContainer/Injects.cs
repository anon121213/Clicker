using ClickSystem;
using LevelSystem;
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

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterModels(builder);
            RegisterViews(builder);
            RegisterPopUp(builder);
        }

        //will be delite
        private void RegisterModels(IContainerBuilder builder)
        {
            builder.Register<UpgradesModel>(Lifetime.Singleton);
            builder.Register<ClickerModel>(Lifetime.Singleton);
        }

        private void RegisterViews(IContainerBuilder builder)
        {
            builder.Register<LevelView>(Lifetime.Singleton);
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
