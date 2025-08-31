using System.Collections.Generic;
using Flappybird.Scripts.Core.Patterns;
using UnityEngine;

namespace Flappybird.Scripts.Gameplay.Coins
{
    public class CoinPool : MonoBehaviourSingleton<CoinPool>
    {
        public const int PoolSize = 8;
        
        [SerializeField] private Transform parent;
        
        public List<GameObject> coinPool;


        /// <summary>
        /// Coin Manager'deki coin prefab'ları alır, sırayla listeye ekler ve Coin havuzu oluşturur. 
        /// </summary>
        public void CreateCoinPool()
        {
            coinPool = new List<GameObject>();
            int index = -1;

            for (int i = 0; i < PoolSize; i++)
            {
                index++;
                
                GameObject coin = Instantiate(CoinManager.Instance.coinPrefabs[index], Vector3.zero, Quaternion.identity, parent);
                coin.SetActive(false);
                coinPool.Add(coin);
            }
        }

        /// <summary>
        /// Coin havuzundan rastgele bir coin çeker ve havuzdan çıkarır aynı zamanda objeyi aktifleştirir.
        /// </summary>
        /// <returns></returns>
        public GameObject GetCoinFromPool()
        {
            if (coinPool.Count > 0)
            {
                var randomIndex = Random.Range(0, coinPool.Count);
                
                GameObject coin = coinPool[randomIndex];
                coinPool.RemoveAt(randomIndex);
                coin.SetActive(true);
                return coin;
            }
            else
                return null;
        }

        /// <summary>
        /// Havuzdan çıkarılan coini havuza tekrar ekleyip objeyi gizler
        /// </summary>
        /// <param name="coin"></param>
        public void ReturnCoinToPool(GameObject coin)
        {
            coin.SetActive(false);
            coinPool.Add(coin);
        }

    }
}