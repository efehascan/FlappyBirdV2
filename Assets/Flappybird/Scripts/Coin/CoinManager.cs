using System;
using System.Collections.Generic;
using Flappybird.Scripts.SingletonPattern;
using Flappybird.Scripts.Wall;
using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class CoinManager : MonoBehaviourSingleton<CoinManager>
    {
        [SerializeField] public GameObject[] coinPrefabs;
        
        private Coroutine spawnCoroutine;
        private readonly WaitForSeconds spawnWait = new WaitForSeconds(15f);
        
        [Header("Coin Settings")]
        [SerializeField] public int coinValue = 0;
        
        public static Action OnCoinValueChanged;

        private void Start()
        {
            CoinPool.Instance.CreateCoinPool();
        }


        public void AddCoin(int amount)
        {
            coinValue += amount;
            OnCoinValueChanged?.Invoke();
        }

        private void SpawnCoin()
        {
            GameObject coin = CoinPool.Instance.GetCoinFromPool();

            if (coin == null)
                return;
            
            
            
        }


        private void DespawnCoin(GameObject coin)
        {
            
            
            
            CoinPool.Instance.ReturnCoinToPool(coin);
        }
        
        
        
        
        
    }
}