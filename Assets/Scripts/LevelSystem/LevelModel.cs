using System;
using UnityEngine;

namespace LevelSystem
{
     public class LevelModel : ILevelModel
     {
          private int _clicksForNewLvl;
          private int _currentLvl;
          private int _currentXp;
          private int _addLvlCount;

          public event Action OnValueChanged;
          
          public int CurrentLvL =>
               _currentLvl;

          public int ClicksForNewLvL =>
               _clicksForNewLvl;

          public int CurrentXp =>
               _currentXp;

          public int AddLvlCount =>
               _addLvlCount;

          public void AddLvL(int value)
          {
               _currentLvl = Mathf.Clamp(_currentLvl + value, 0, Int32.MaxValue);
               OnValueChanged?.Invoke();
          }

          public void AddXp(int value)
          {
               _currentXp = Mathf.Clamp(_currentXp + value, 0, Int32.MaxValue);
               OnValueChanged?.Invoke();
          }

          public void AddClicksForNewLvl(int value)
          {
               _clicksForNewLvl = Mathf.Clamp(_clicksForNewLvl + value, 0, Int32.MaxValue);
               OnValueChanged?.Invoke();
          }

          public void TryUpgradeLevel(int currentXp, int clickPrice, int clicksForNewLvl, int clickXpPrice, int addLvl)
          {
               int newXp = currentXp + clickPrice;
               
               if (newXp < clicksForNewLvl)
                    AddXp(clickXpPrice);
               else
               {
                    RemoveCurrentClicks();
                    AddLvL(addLvl);
                    AddClicksForNewLvl(clicksForNewLvl);
               }
          }

          public void ChangeLvlCount(int value)
          {
               _addLvlCount = Mathf.Clamp(_addLvlCount + value, 0, Int32.MaxValue);
               OnValueChanged?.Invoke();
          }
          
          public void RemoveCurrentClicks()
          {
               _currentXp = 0;
               OnValueChanged?.Invoke();
          }
     }
}
