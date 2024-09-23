using System;
using UnityEngine;

namespace _Scripts.Data.Enemy
{
    [Serializable]
    public struct EnemyData
    {
        public Sprite _sprite;
        public float _health;
        public float _attack;
    }
}