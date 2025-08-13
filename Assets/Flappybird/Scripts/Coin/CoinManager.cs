using System;
using Flappybird.Scripts.SingletonPattern;
using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class CoinManager : MonoBehaviourSingleton<CoinManager>
    {
        [Header("Settings")]
        [SerializeField] public int coinValue = 0;
        
        public static Action OnCoinValueChanged;


        public void CollectBronzCoin()
        {
            coinValue++;
            OnCoinValueChanged?.Invoke();
        }

        public void CollectSilverCoin()
        {
            coinValue = coinValue + 10;
            OnCoinValueChanged?.Invoke();
        }


        public void CollectGoldCoin()
        {
            coinValue = coinValue + 50;
            OnCoinValueChanged?.Invoke();
        }
        

    }
}