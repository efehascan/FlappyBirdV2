using Flappybird.Scripts.Coin;
using Flappybird.Scripts.Point;
using Flappybird.Scripts.SingletonPattern;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Scripts.Managers.InGame
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        
    }
}