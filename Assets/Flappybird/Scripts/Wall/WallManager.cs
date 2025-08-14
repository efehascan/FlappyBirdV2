using System;
using System.Collections;
using System.Collections.Generic;
using Flappybird.Scripts.SingletonPattern;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Flappybird.Scripts.Wall
{
    public class WallManager : MonoBehaviourSingleton<WallManager>
    {
        private const int PoolSize = 26;
        
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private float spawnXOffset = 15;
        
        private float yMinOffset = -1.75f;
        
        private Coroutine spawnCoroutine;
        private readonly WaitForSeconds spawnRoutine = new WaitForSeconds(5f);
        
        private List<GameObject> wallPool;

        private void Start()
        {
            CreatePool();

            spawnCoroutine = StartCoroutine(StartSpawnCoroutine());
        }


        private void CreatePool()
        {
            wallPool = new List<GameObject>();


            for (int i = 0; i < PoolSize; i++)
            {
                float yPos = yMinOffset + (i * 0.25f);
                
                Vector3 position = new Vector3(0, yPos, 0); 
                GameObject wall = Instantiate(wallPrefab, position, Quaternion.identity);
                wall.SetActive(false);
                wallPool.Add(wall);
            }
        }

        private GameObject GetWallFromPool()
        {
            if (wallPool.Count > 0)
            {
                int randomIndex = Random.Range(0, wallPool.Count);
                
                GameObject wall = wallPool[randomIndex];
                wall.SetActive(true);
                return wall;
                
            } else
                return null;
            
            
        }

        private void ReturnWallToPool(GameObject wall)
        {
            wall.SetActive(false);
            wallPool.Add(wall);
        }

        private void SpawnWall()
        {
            GameObject wall = GetWallFromPool();
            
            if (wall == null)
                return;
            
            Vector3 position = wall.transform.position;
            position.x += spawnXOffset;
            wall.transform.position = position;

            if (!wall.TryGetComponent<WallMovement>(out _))
            {
                wall.AddComponent<WallMovement>();
            }
        }


        public void DespawnWall(GameObject wall)
        {
            var moveComponent = wall.GetComponent<WallMovement>();

            if (moveComponent != null)
            {
                Destroy(moveComponent);
            }
            
            Vector3 position = wall.transform.position;
            position.x = 0f;
            wall.transform.position = position;
            
            
            ReturnWallToPool(wall);
        }


        private IEnumerator StartSpawnCoroutine()
        {
            while (true)
            {
                SpawnWall();

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