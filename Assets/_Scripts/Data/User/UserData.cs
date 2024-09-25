using System.Collections.Generic;

namespace _Scripts.Data.User
{
    public class UserData
    {
        public int _battleCount;
        public List<int> _ownedHeroIds; //HASH SET NONSERILIZABLE
        public List<int> _ownedHeroExperience; //DICTINORY NONSERILIZABLE

        public UserData(int battleCount = 0)
        {
            _battleCount = battleCount;
            _ownedHeroIds = new List<int>();
            _ownedHeroExperience = new List<int>();
        }

        public int GetBattleCount()
        {
            return _battleCount;
        }

        public void IncreaseBattleCount()
        {
            _battleCount++;
        }

        public void AddHeroToUser(int heroId)
        {
            _ownedHeroExperience.Add(0);
            _ownedHeroIds.Add(heroId);
        }
        
        public List<int> GetOwnedHeroIds()
        {
            return _ownedHeroIds;
        }

        public void IncreaseExperienceById(int Id)
        {
            for (int i = 0; i < _ownedHeroIds.Count; i++)
            {
                if (Id == _ownedHeroIds[i])
                {
                    _ownedHeroExperience[i]++;
                }
            }
        }

        public int GetExperienceById(int Id)
        {
            for (int i = 0; i < _ownedHeroIds.Count; i++)
            {
                if (Id == _ownedHeroIds[i])
                {
                    return _ownedHeroExperience[i];
                }
            }

            return -1;
        }
    }
}