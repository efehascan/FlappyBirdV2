using Flappybird.Scripts.Coin;
using Flappybird.Scripts.Point;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Scripts.Managers.InGame
{
    public class FinishMenuManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI collectedCoinsText;
        [SerializeField] private TextMeshProUGUI currentScoreText;
        
        
        private void UpdateText()
        {
            collectedCoinsText.text = "Collected Coins: " + CoinManager.Instance.runCoinValue;

            currentScoreText.text = "Current Score: " + PointManager.Instance.score;
        }

        
        private void ReturnMainMenu()
        {
            
        SceneManager.LoadScene("MainMenu");}
        
        
        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        
    }
}