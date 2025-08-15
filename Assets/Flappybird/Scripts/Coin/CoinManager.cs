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
        public const string Camera = "MainCamera";
        [SerializeField] public GameObject[] coinPrefabs;
        
        private Coroutine spawnCoroutine;
        private readonly WaitForSeconds spawnRoutine = new WaitForSeconds(2.5f);
        
        
        [Header("Coin Settings")]
        [SerializeField] public int runCoinValue = 0;
        
        public static Action OnCoinValueChanged;

        private void Start()
        {
            CoinPool.Instance.CreateCoinPool();
            
            
            spawnCoroutine = StartCoroutine(StartSpawnCoroutine());
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
            
            
            
            if (!coin.TryGetComponent<WallMovement>(out _))
                coin.AddComponent<WallMovement>();
        }


        public void DespawnCoin(GameObject coin)
        {
            var moveComponent = coin.GetComponent<WallMovement>();
            
            if (moveComponent != null)
                Destroy(moveComponent);
            
            Vector3 position = coin.transform.position;
            position = new Vector3(0f, 0f, 0f);
            coin.transform.position = position;
            
            
            CoinPool.Instance.ReturnCoinToPool(coin);
        }
        
        
        private IEnumerator StartSpawnCoroutine()
        {
            while (true)
            {
                SpawnCoin();

                yield return spawnRoutine;
            }
        }


        private void OnDisable()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }

        private void OnDestroy()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }
        
        
        
        
    }
}