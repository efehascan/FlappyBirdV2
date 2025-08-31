using System;
using Flappybird.Scripts.Managers;
using Flappybird.Scripts.SingletonPattern;
using UnityEngine;

namespace Flappybird.Scripts.Wallet
{
    public class WalletService  : MonoBehaviourSingletonPersistent<WalletService>
    {
        public static Action onCoinsChanged;
        private int coins;


        public override void Awake()
        {
            base.Awake();
            
            
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
            Save(coins);
        }
        
        public void Save(int totalCoins)
        {
            FileSaveManager.Instance.SetWallet(totalCoins);
            onCoinsChanged?.Invoke();
        }


    }
}