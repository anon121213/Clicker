namespace LevelSystem
{
    public interface ILevelView
    {
        public void UpdateLevel(int currentClick, int clickForNewLevel);
        public void UpdateClicksForNewLvlText(int clicksForNewLvl, int newLevel);
    }
}
