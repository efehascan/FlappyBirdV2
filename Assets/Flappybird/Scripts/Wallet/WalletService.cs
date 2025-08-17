using System;
using Flappybird.Scripts.Managers;
using Flappybird.Scripts.SingletonPattern;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

namespace Flappybird.Scripts.Wallet
{
    public class WalletService  : MonoBehaviourSingleton<WalletService>
    {
        public static Action onCoinsChanged;
        private int coins;


        private void Awake()
        {
            onCoinsChanged?.Invoke();
        }

        public void AddCoinToWallet(int amount)
        {
            if (amount < 0)
            {
                Debug.LogError("Para eksi nasıl gelsin amına koyayım");
                return;
            }
            
            coins += amount;
            
        }
        
        public void Save(int totalCoins)
        {
            FileSaveManager.Instance.SetWallet(totalCoins);
            onCoinsChanged?.Invoke();
        }


    }
}