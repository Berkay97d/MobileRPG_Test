using System.Collections.Generic;

namespace _Scripts.Data.User
{
    public class UserData
    {
        public int _battleCount;
        public List<int> _ownedHeroIds;

        public UserData(int battleCount = 0)
        {
            _battleCount = battleCount;
            _ownedHeroIds = new List<int>();
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
    }
}