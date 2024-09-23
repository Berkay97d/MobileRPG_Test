using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Buttons
{
    public class MenuButtonManager : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;


        private void Start()
        {
            Army.OnArmyChanged += OnArmyChanged;
            
            _startButton.interactable = false;
            _startButton.onClick.AddListener(LoadBattleScene);
            
            _quitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

        private void OnDestroy()
        {
            Army.OnArmyChanged -= OnArmyChanged;
        }

        private void OnArmyChanged(bool isArmyFull)
        {
            if (isArmyFull)
            {
                _startButton.interactable = true;
                return;
            }
            
            _startButton.interactable = false;
        }

        private void LoadBattleScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}