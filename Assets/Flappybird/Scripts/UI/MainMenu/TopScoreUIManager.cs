using Flappybird.Scripts.Core.Services;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.UI.MainMenu
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