using System;
using Flappybird.Scripts.SingletonPattern;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

namespace Flappybird.Scripts.Wallet
{
    public class WalletService  : MonoBehaviourSingleton<WalletService>
    {
        public static Action onCoinsChanged;
        private const string WalletKey = "wallet_coins";
        private int coins;


        private void Awake()
        {
            Load();
            onCoinsChanged?.Invoke();
        }

        private void AddCoinToWallet(int amount)
        {
            if (amount < 0)
                return;
            
            coins += amount;
            
        }

        
        public void Save(int totalCoins)
        {
            PlayerPrefs.SetInt(WalletKey, totalCoins);
            PlayerPrefs.Save();
            onCoinsChanged?.Invoke();
        }

        public static int Load()
        {
            onCoinsChanged?.Invoke();
            return PlayerPrefs.GetInt(WalletKey, 0);
        }

    }
}