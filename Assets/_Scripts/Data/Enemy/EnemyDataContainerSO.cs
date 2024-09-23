using _Scripts.Data.User;
using UnityEngine;

namespace _Scripts.Data.Enemy
{
    [CreateAssetMenu]
    public class EnemyDataContainerSO : ScriptableObject
    {
        public EnemyData[] enemyDatas;

        
        public EnemyData GetEnemyDataByBattleCount()
        {
            return enemyDatas[SaveSystem.GetUserData().GetBattleCount()];
        }
    }
}