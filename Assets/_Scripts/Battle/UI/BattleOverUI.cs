using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Battle.UI
{
    public class BattleOverUI : MonoBehaviour
    {
        [SerializeField] private Transform _mainTransform;
        [SerializeField] private TMP_Text _winLoseText;
        [SerializeField] private Button _menuButton;
        

        private void Start()
        {
            _menuButton.onClick.AddListener(() => SceneManager.LoadScene(0));
            
            BattleController.OnFightOver += OnFightOver;
        }

        private void OnDestroy()
        {
            BattleController.OnFightOver -= OnFightOver;
        }

        private void OnFightOver(OnFightOverArgs eventArgs)
        {
            StartCoroutine(UIRoutine());
            
            IEnumerator UIRoutine()
            {
                yield return new WaitForSeconds(4f);

                _winLoseText.text = eventArgs.GetIsWin() ? "YOU WİN!" : "YOU LOST!";

                _mainTransform.gameObject.SetActive(true);

            }
        }
    }
}