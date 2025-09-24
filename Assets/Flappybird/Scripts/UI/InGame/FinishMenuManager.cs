using Flappybird.Scripts.Core.Patterns;
using Flappybird.Scripts.Gameplay.Coins;
using Flappybird.Scripts.Gameplay.Player;
using Flappybird.Scripts.Gameplay.Points;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Scripts.UI.InGame
{
    public class FinishMenuManager : MonoBehaviourSingleton<FinishMenuManager>
    {
        [SerializeField] private TextMeshProUGUI collectedCoinsText;
        [SerializeField] private TextMeshProUGUI currentScoreText;
        
        
        
        public void RefreshText()
        {
            collectedCoinsText.text = "Collected Coins: " + CoinManager.Instance.runCoinValue;

            currentScoreText.text = "Current Score: " + PointManager.Instance.score;
        }

        
        public void ReturnMainMenu()
        {
            SceneManager.LoadSceneAsync(0);
        }
        
        
        public void RestartGame()
        {
            PlayerManager.Instance.ReturnStartPosition();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        
    }
}