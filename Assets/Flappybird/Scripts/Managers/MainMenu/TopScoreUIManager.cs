using System;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.Managers.MainMenu
{
    public class TopScoreUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text topScoreText;


        private void Start()
        {
            topScoreText.text = "Top Score: " + FileSaveManager.Instance.GetTopScore();
        }
    }
}