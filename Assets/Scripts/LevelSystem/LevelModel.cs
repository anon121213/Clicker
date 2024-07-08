namespace LevelSystem
{
     public class LevelModel
     {
          private int _currentLvl = 1;
          private int _clicksForNewLvl = 100;
          private int _currentClicks = 0;

          public int GetCurrentLvL()
          {
               return _currentLvl;
          }

          public int GetClicksForNewLvL()
          {
               return _clicksForNewLvl;
          }

          public int GetCurrentClicks()
          {
               return _currentClicks;
          }

          public void IncrementLvL()
          {
               _currentLvl++;
          }

          public void IncrementClicks(int value)
          {
               _currentClicks += value;
          }
     
          public void IncrementClicksForNewLvl()
          {
               _clicksForNewLvl *= 2;
          }

          public void DecrimentCuddentClicks()
          {
               _currentClicks = 0;
          }
     }
}
