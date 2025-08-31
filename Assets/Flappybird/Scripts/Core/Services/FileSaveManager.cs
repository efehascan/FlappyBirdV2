using Flappybird.Scripts.Core.Patterns;
using UnityEngine;

namespace Flappybird.Scripts.Core.Services
{
    public class FileSaveManager : MonoBehaviourSingletonPersistent<FileSaveManager>
    {
        private const string CoinKey = "coin";
        private const string TopScoreKey = "topScore";

        public override void Awake()
        {
            base.Awake();
            CheckPref(CoinKey);
            CheckPref(TopScoreKey);
        }

        // Genel pref kontrolcüsü
        private void CheckPref(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key, 0);
                PlayerPrefs.Save();
            }
        }

        // WALLET 
        public void SetWallet(int totalCoins)
        {
            PlayerPrefs.SetInt(CoinKey, totalCoins);
            PlayerPrefs.Save();
        }

        public int GetWallet()
        {
            return PlayerPrefs.GetInt(CoinKey, 0);
        }

        // TOP SCORE 
        public void TrySetNewTopScore(int score)
        {
            int currentTop = PlayerPrefs.GetInt(TopScoreKey, 0);
            if (score > currentTop)
            {
                PlayerPrefs.SetInt(TopScoreKey, score);
                PlayerPrefs.Save();
            }
        }

        public int GetTopScore()
        {
            return PlayerPrefs.GetInt(TopScoreKey, 0);
        }
    }
}