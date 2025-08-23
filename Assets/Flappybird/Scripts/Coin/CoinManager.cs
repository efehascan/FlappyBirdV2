using System;
using System.Collections;
using System.Linq;
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
        
        private GameObject firstWall;
        private GameObject secondWall;
        
        [Header("Coin Settings")]
        [SerializeField] public int runCoinValue = 0;
        
        public static Action OnCoinValueChanged;
        
        
        private void Awake()
        {
            CoinPool.Instance.CreateCoinPool();
            
            InvokeRepeating(nameof(SpawnCoin), 0, spawnInterval);
            
        }


        public void AddCoin(int amount)
        {
            runCoinValue += amount;
            OnCoinValueChanged?.Invoke();
        }

        private void SpawnCoin()
        {
            CalculateXPositions();
            if (firstWall == null || secondWall == null)
                return;
            
            GameObject coin = CoinPool.Instance.GetCoinFromPool();

            if (coin == null)
                return;
            
            float firstX = firstWall.transform.position.x;
            float secondX = secondWall.transform.position.x;
            
            Debug.Log("FirstX" + firstX);
            Debug.Log("Secondx " + secondX);
            
            float randomX = UnityEngine.Random.Range(secondX + 1.5f, firstX - 1.5f);
            float randomY = UnityEngine.Random.Range(-3.5f, 4f);
            
            Debug.Log("RandomX" + randomX);
            
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            coin.transform.position = spawnPosition;
            
        }


        public void DespawnCoin(GameObject coin)
        {
            CoinPool.Instance.ReturnCoinToPool(coin);
        }

        public void CalculateXPositions()
        {
            var top2 = WallManager.Instance.activeWalls
                .OrderByDescending(obj => obj.transform.position.x)
                .Take(2)
                .ToList();

            if (top2.Count >= 2)
            {
                firstWall = top2[0];
                secondWall = top2[1];
            }
            
        }


        private void OnDisable()
        {
            CancelInvoke(nameof(SpawnCoin));
        }
    }
}