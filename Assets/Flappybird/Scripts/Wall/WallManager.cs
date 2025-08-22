using System;
using System.Collections;
using Flappybird.Scripts.SingletonPattern;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Flappybird.Scripts.Wall
{
    public class WallManager : MonoBehaviourSingleton<WallManager>
    {
        [SerializeField] public GameObject wallPrefab;
        [SerializeField] private float spawnXOffset = 15;
        [SerializeField] private float spawnMaxYOffset = 4.5f;
        [SerializeField] private float spawnMinYOffset = -2.5f;
        [SerializeField] private float spawnInterval = 2.5f;
        
        private Coroutine spawnCoroutine;
        

        private void Awake()
        {
            WallPool.Instance.CreateWallPool();
            
            InvokeRepeating(nameof(SpawnWall), 0f, spawnInterval);
        }

        

        private void SpawnWall()
        {
            GameObject wall = WallPool.Instance.GetWallFromPool();
            
            if (wall == null)
                return;
            
            Vector3 spawnPosition = new Vector3(spawnXOffset, Random.Range(spawnMinYOffset, spawnMaxYOffset), 0);
            
            wall.transform.position = spawnPosition;
        }


        public void DespawnWall(GameObject wall)
        {
            WallPool.Instance.ReturnWallToPool(wall);
        }


        private void OnDisable()
        {
            CancelInvoke(nameof(SpawnWall));
        }
    }
}
