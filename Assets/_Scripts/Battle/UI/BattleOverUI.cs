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
        [SerializeField] private BattleController _battleController;
        [SerializeField] private Transform _mainTransform;
        [SerializeField] private TMP_Text _winLoseText;
        [SerializeField] private Button _menuButton;
        

        private void Start()
        {
            _menuButton.onClick.AddListener(() => SceneManager.LoadScene(0));
            
            _battleController.OnFightOver += OnFightOver;
        }

        private void OnDestroy()
        {
            _battleController.OnFightOver -= OnFightOver;
        }

        private void OnFightOver(bool isWin)
        {
            StartCoroutine(UIRoutine());
            
            IEnumerator UIRoutine()
            {
                yield return new WaitForSeconds(3f);

                _winLoseText.text = isWin ? "YOU WİN!" : "YOU LOST!";

                _mainTransform.gameObject.SetActive(true);

            }
        }
    }
}