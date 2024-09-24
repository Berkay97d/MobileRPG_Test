using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Battle
{
    public class HealthVisual : MonoBehaviour
    {
        [SerializeField] private Health _health; 
        [SerializeField] private Image _healthBarRed;
        [SerializeField] private Image _healthBarWhite;
        [SerializeField] private float _whiteBarDelay;
        [SerializeField] private float _whiteBarReduceTime;
        
        
        
        private void Awake()
        {
            _health.OnDamaged += OnDamaged;
        }

        private void OnDestroy()
        {
            _health.OnDamaged -= OnDamaged;
        }

        private void OnDamaged()
        {
            UpdateHealthBar();
        }
        
        private void UpdateHealthBar()
        {
            StartCoroutine(UpdateHealthRoutine());
            
            IEnumerator UpdateHealthRoutine()
            {
                float fillAmount = _health.GetCurrentHealth() / _health.GetMaxHealth();
                
                _healthBarRed.fillAmount = fillAmount;

                yield return new WaitForSeconds(_whiteBarDelay);
                
                _healthBarWhite.DOFillAmount(fillAmount, _whiteBarReduceTime)
                    .SetEase(Ease.OutSine);
            }
            
        }
    }
}