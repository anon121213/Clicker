using UpgradeSystem;

namespace LevelSystem
{
     public class LevelModel
     {
          public int ClicksForNewLvl;
          
          private int CurrentLvl;
          private int CurrentClicks;

          public LevelModel(LevelView levelView, UpgradesModel upgradesModel)
          {
               new LevelPresenter(levelView, this, upgradesModel);
          }
          
          public int GetCurrentLvL()
          {
               return CurrentLvl;
          }

          public int GetClicksForNewLvL()
          {
               return ClicksForNewLvl;
          }

          public int GetCurrentClicks()
          {
               return CurrentClicks;
          }

          public void IncrementLvL(int value)
          {
               CurrentLvl += value;
          }

          public void IncrementClicks(int value)
          {
               CurrentClicks += value;
          }
     
          public void IncrementClicksForNewLvl()
          {
               ClicksForNewLvl *= 2;
          }

          public void DecrimentCuddentClicks()
          {
               CurrentClicks = 0;
          }
     }
}
