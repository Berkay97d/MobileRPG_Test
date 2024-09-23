using System;
using System.Collections.Generic;

namespace _Scripts
{
    public enum ArmyActionResult
    {
        ADDED,
        REMOVE,
        ARMY_FULL
    }
    
    public static class Army
    {
        private static int MS_MAX_ARMY_COUNT = 3;
        private static List<HeroData> MS_HEROES = new List<HeroData>();

        public static event Action<bool> OnArmyChanged; 

        public static ArmyActionResult DoAddRemoveArmyActions(HeroData heroData)
        {
            if (MS_HEROES.Contains(heroData))
            {
                MS_HEROES.Remove(heroData);
                OnArmyChanged?.Invoke(false);
                return ArmyActionResult.REMOVE;
            }
            
            if (MS_HEROES.Count >= MS_MAX_ARMY_COUNT) return ArmyActionResult.ARMY_FULL;
            
            MS_HEROES.Add(heroData);
            OnArmyChanged?.Invoke(MS_HEROES.Count == MS_MAX_ARMY_COUNT);
            return ArmyActionResult.ADDED;
        }

        public static List<HeroData> GetAllHeroDatas()
        {
            return MS_HEROES;
        }

        
    }
}