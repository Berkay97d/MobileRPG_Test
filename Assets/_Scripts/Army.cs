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



        public static ArmyActionResult DoAddRemoveArmyActions(HeroData heroData)
        {
            if (MS_HEROES.Contains(heroData))
            {
                MS_HEROES.Remove(heroData);
                return ArmyActionResult.REMOVE;
            }
            
            if (MS_HEROES.Count >= MS_MAX_ARMY_COUNT) return ArmyActionResult.ARMY_FULL;
            
            MS_HEROES.Add(heroData);
            return ArmyActionResult.ADDED;
        }

        
    }
}