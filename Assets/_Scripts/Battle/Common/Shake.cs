using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Battle
{
    public class Shake : MonoBehaviour
    {
         private static float shakeDuration = 0.5f;  
         private static float shakeStrength = 10f;  
         private static int vibrato = 10;            

        private Vector3 m_startPos;
        
        private void Start()
        {
            m_startPos = transform.localPosition;
            BattleHeroAttacker.OnPlayerHit += OnPlayerHit;
        }
        
        private void OnDestroy()
        {
            BattleHeroAttacker.OnPlayerHit -= OnPlayerHit;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DoShake();
            }
        }
        
        private void OnPlayerHit(HeroData heroData)
        {
            DoShake();
        }

        private void DoShake()
        {
            Debug.Log("AAAAAAAAAAAAAAAAA");
            transform
                .DOShakePosition(shakeDuration, shakeStrength, vibrato)
                .OnComplete(() => transform.localPosition = m_startPos); 
        }
    }
}