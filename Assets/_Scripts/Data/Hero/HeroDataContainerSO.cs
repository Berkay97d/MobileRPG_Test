using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu]
    public class HeroDataContainerSO : ScriptableObject
    {
        public HeroData[] _heroDatas;
        
        
        private void OnValidate()
        {
            var usedIds = new HashSet<int>();

            for (int i = 0; i < _heroDatas.Length; i++)
            {
                if (_heroDatas[i]._heroID != 0)
                {
                    usedIds.Add(_heroDatas[i]._heroID);
                }
            }

            for (int i = 0; i < _heroDatas.Length; i++)
            {
                if (_heroDatas[i]._heroID == 0 || usedIds.Contains(_heroDatas[i]._heroID))
                {
                    _heroDatas[i]._heroID = i;
                    usedIds.Add(i);
                }
            }
        }

        public HeroData GetHeroDataById(int Id)
        {
            foreach (var heroData in _heroDatas)
            {
                if (heroData._heroID == Id)
                {
                    return heroData;
                }
            }
            
            Debug.LogError("Unreachable Code");
            return new HeroData();
        }

        public HeroData[] GetAllHeroDatas()
        {
            return _heroDatas;
        }
        
    }
}