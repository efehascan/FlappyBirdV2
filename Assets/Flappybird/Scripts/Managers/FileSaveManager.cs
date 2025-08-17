using Flappybird.Scripts.SingletonPattern;
using UnityEngine;

namespace Flappybird.Scripts.Managers
{
    public class FileSaveManager : MonoBehaviourSingletonPersistent<FileSaveManager>
    {
        private const string CoinKey = "coin";

            

        public override void Awake()
        {
            base.Awake();
            CheckWalletPref();
        }

        
        private void CheckWalletPref()
        {
            if (!PlayerPrefs.HasKey(CoinKey))
            {
                PlayerPrefs.SetInt(CoinKey, 0);
                PlayerPrefs.Save();
            }
        }
        
        public void SetWallet(int totalCoins)
        {
            PlayerPrefs.SetInt(CoinKey, totalCoins);
            PlayerPrefs.Save();
        }

        public int GetWalletKey()
        {
            return PlayerPrefs.GetInt(CoinKey);
        } 

    }
}