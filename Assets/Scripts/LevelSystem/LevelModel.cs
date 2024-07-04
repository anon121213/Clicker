public class LevelModel
{
     private int _currentLvl = EntryPoint.Instance.PlayerData.CurrentLvl;
     private int _clicksForNewLvl = EntryPoint.Instance.PlayerData.ClicksForNewLvl;
     private int _currentClicks = EntryPoint.Instance.PlayerData.CurrentClicks;

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
