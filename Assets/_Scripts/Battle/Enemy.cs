﻿using System;
using UnityEngine;

namespace _Scripts.Battle
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Health _health;
        
        

        private void Awake()
        {
            _health.SetMaxHealth(10);
        }

        public Health GetHealth()
        {
            return _health;
        }
        
    }
}