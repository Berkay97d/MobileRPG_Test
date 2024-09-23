using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.HeroSelectionPage
{
    public class MarketHeroClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnShortPress;  
        public event Action OnLongPressStart;  
        public event Action OnLongPressEnd;  

        private static float MS_TIME_THRESHOLD = 3.0f; 
        private bool m_isHolding;    
        private float m_holdTime;        
        private bool m_longPressTriggered; 

        private void Update()
        {
            if (!m_isHolding) return;
            
            m_holdTime += Time.deltaTime; 
            
            if (m_holdTime >= MS_TIME_THRESHOLD && !m_longPressTriggered)
            {
                OnLongPressStart?.Invoke(); 
                m_longPressTriggered = true; 
            }
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            m_isHolding = true;      
            m_holdTime = 0f;        
            m_longPressTriggered = false;

            Debug.Log("POİNTER DOWN");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_isHolding = false;   
            
            if (!m_longPressTriggered)
            {
                OnShortPress?.Invoke();
                return;
            }
            Debug.Log("POİNTER Up");
            OnLongPressEnd?.Invoke();
        }

        
    }
}