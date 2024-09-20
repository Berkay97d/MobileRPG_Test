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
        
        
        
    }
}