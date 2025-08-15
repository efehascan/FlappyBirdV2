using UnityEngine;
using System.Collections.Generic;

using Flappybird.Scripts.SingletonPattern;

namespace Flappybird.Scripts.Wall
{
    public class WallPool : MonoBehaviourSingleton<WallPool>
    {
        private const int PoolSize = 26;
        
        [SerializeField] private Transform parent;
        
        private List<GameObject> wallPool;
        
        
        private float yMinOffset = -1.75f;
        
        
        public void CreateWallPool()
        {
            wallPool = new List<GameObject>();


            for (int i = 0; i < PoolSize; i++)
            {
                float yPos = yMinOffset + (i * 0.25f);
                
                Vector3 position = new Vector3(0, yPos, 0); 
                GameObject wall = Instantiate(WallManager.Instance.wallPrefab, position, Quaternion.identity,  parent);
                wall.SetActive(false);
                wallPool.Add(wall);
            }
        }

        public GameObject GetWallFromPool()
        {
            if (wallPool.Count > 0)
            {
                int randomIndex = Random.Range(0, wallPool.Count);
                
                GameObject wall = wallPool[randomIndex];
                wallPool.RemoveAt(randomIndex);
                wall.SetActive(true);
                return wall;
                
            } else
                return null;
            
            
        }

        public void ReturnWallToPool(GameObject wall)
        {
            wall.SetActive(false);
            wallPool.Add(wall);
        }
        
    }
}