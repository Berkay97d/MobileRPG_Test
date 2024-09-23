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

        private void Start()
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
                Debug.Log(_health.GetCurrentHealth());
                Debug.Log(_health.GetMaxHealth());
                Debug.Log(fillAmount);
                _healthBarRed.DOFillAmount(fillAmount, .2f);

                yield return new WaitForSeconds(1f);
                
                _healthBarWhite.DOFillAmount(fillAmount, .4f);
            }
            
        }
    }
}