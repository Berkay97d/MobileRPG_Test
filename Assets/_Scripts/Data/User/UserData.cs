using System.Collections.Generic;

namespace _Scripts.Data.User
{
    public class UserData
    {
        public int _battleCount;
        public List<int> _ownedHeroIds; //HASH SET NONSERILIZABLE
        public List<int> _idToExperience; //DICTINORY NONSERILIZABLE

        public UserData(int battleCount = 0)
        {
            _battleCount = battleCount;
            _ownedHeroIds = new List<int>();
            _idToExperience = new List<int>();;
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
                    _idToExperience[i]++;
                }
            }
        }

        public int GetExperienceById(int Id)
        {
            for (int i = 0; i < _ownedHeroIds.Count; i++)
            {
                if (Id == _ownedHeroIds[i])
                {
                    return _idToExperience[i];
                }
            }

            return -1;
        }
    }
}