using UnityEngine;
using System.Collections.Generic;
using Flappybird.Scripts.SingletonPattern;

namespace Flappybird.Scripts.Wall
{
    public class WallPool : MonoBehaviourSingleton<WallPool>
    {
        private const int PoolSize = 5;
        
        [SerializeField] private Transform parent;

        public List<GameObject> wallPool;


        public void CreateWallPool()
        {
            wallPool = new List<GameObject>();
            
            for (int i = 0; i < PoolSize; i++)
            {
                AddWallToPool();
            }
        }

        public GameObject GetWallFromPool()
        {
            foreach (var walls in wallPool)
            { 
                if (!walls.activeSelf)
                {
                    walls.SetActive(true);
                    return walls; 
                }
            }
                
            AddWallToPool();

            GameObject newWall = wallPool[wallPool.Count - 1];
            return newWall;
        }

        public void ReturnWallToPool(GameObject wall)
        {
            wall.SetActive(false);
        }

        private void AddWallToPool()
        {
            GameObject wall = Instantiate(WallManager.Instance.wallPrefab, Vector3.zero, Quaternion.identity,  parent);
            wall.SetActive(false);
            wallPool.Add(wall);
        }
        
    }
}