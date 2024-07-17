using UpgradeSystem.Models;

namespace ClickSystem
{
    public class ClickService : IClickService
    {
        private IClickerModel _clikerModel;
        private IUpgradesMoneyModel _ugradesMoneyModel;
        
        public ClickService(IClickerModel clickerModel,
            IUpgradesMoneyModel upgradesMoneyModel)
        {
            _clikerModel = clickerModel;
            _ugradesMoneyModel = upgradesMoneyModel;
        }
        
        public void OnClick() =>
            _clikerModel.AddMoney(_ugradesMoneyModel.ClickPrice);
    }
}