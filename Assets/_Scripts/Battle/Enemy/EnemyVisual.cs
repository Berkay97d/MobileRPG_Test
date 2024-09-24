using System;
using _Scripts.Data.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Battle
{
    public class EnemyVisual : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Image _image;

        private void Awake()
        {
            _enemy.OnEnemyDataSetted += OnEnemyDataSetted;
        }

        private void OnDestroy()
        {
            _enemy.OnEnemyDataSetted -= OnEnemyDataSetted;
        }

        private void OnEnemyDataSetted(EnemyData enemyData)
        {
            _image.sprite = enemyData._sprite;
        }
    }
}