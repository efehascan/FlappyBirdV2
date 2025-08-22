using System;
using System.Collections;
using Flappybird.Scripts.SingletonPattern;
using Flappybird.Scripts.Wall;
using UnityEngine;
using UnityEngine.Serialization;

namespace Flappybird.Scripts.Coin
{
    public class CoinManager : MonoBehaviourSingleton<CoinManager>
    {

        [SerializeField] public GameObject[] coinPrefabs;
        [SerializeField] private float spawnInterval = 2.5f;
        
        private Coroutine spawnCoroutine;
        

        [Header("Coin Settings")]
        [SerializeField] public int runCoinValue = 0;
        
        public static Action OnCoinValueChanged;
        
        
        private void Awake()
        {
            CoinPool.Instance.CreateCoinPool();
            
            InvokeRepeating(nameof(SpawnCoin), 0f, spawnInterval);
            
        }


        public void AddCoin(int amount)
        {
            runCoinValue += amount;
            OnCoinValueChanged?.Invoke();
        }

        private void SpawnCoin()
        {
            GameObject coin = CoinPool.Instance.GetCoinFromPool();

            if (coin == null)
                return;
            
            float randomX = UnityEngine.Random.Range(17f, 21.5f);
            float randomY = UnityEngine.Random.Range(-3.5f, 4f);
            
            
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            coin.transform.position = spawnPosition;
            
        }


        public void DespawnCoin(GameObject coin)
        {
            CoinPool.Instance.ReturnCoinToPool(coin);
        }


        private void OnDisable()
        {
            CancelInvoke(nameof(SpawnCoin));
        }
    }
}