using System;
using System.Collections.Generic;
using Flappybird.Scripts.SingletonPattern;
using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class CoinManager : MonoBehaviourSingleton<CoinManager>
    {
        [Header("Settings")]
        [SerializeField] public int coinValue = 0;
        
        public static Action OnCoinValueChanged;
        
        public void AddCoin(int amount)
        {
            coinValue += amount;
            OnCoinValueChanged?.Invoke();
        }
        
    }
}