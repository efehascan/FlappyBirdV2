using Flappybird.Scripts.Gameplay.Points;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.UI.InGame
{
    public class ScoreUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        
        private void OnEnable()
        {
            PointManager.onScoreChanged += UpdateScoreUI;
        }

        private void UpdateScoreUI(int currentScore)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }

        
        private void OnDisable()
        {
            PointManager.onScoreChanged -= UpdateScoreUI;
        }

    }
}