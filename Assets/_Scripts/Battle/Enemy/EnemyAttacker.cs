using UnityEngine;

namespace _Scripts.Battle
{
    public class EnemyAttacker : MonoBehaviour
    {
        private void Start()
        {
            BattleHeroAttacker.OnPlayerAttackEnd += OnPlayerAttackEnd;
        }

        private void OnDestroy()
        {
            BattleHeroAttacker.OnPlayerAttackEnd -= OnPlayerAttackEnd;
        }

        private void OnPlayerAttackEnd()
        {
            
        }
    }
}