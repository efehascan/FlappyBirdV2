using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Flappybird.Scripts.Wall
{
    public class WallController : MonoBehaviour
    {
        private const int PoolSize = 26;
        
        [SerializeField] private GameObject wallPrefab;
        
        private float yMinOffset = -1.75f;
        
        
        private Queue<GameObject> wallPool;

        private void Start()
        {
            wallPool = new Queue<GameObject>();


            for (int i = 0; i < PoolSize; i++)
            {
                float yPos = yMinOffset + (i * 0.25f);
                
                Vector3 position = new Vector3(0, yPos, 0); 
                GameObject wall = Instantiate(wallPrefab, position, Quaternion.identity);
                wall.SetActive(true);
                wallPool.Enqueue(wall);
            }
        }

        private GameObject GetWallFromPool(GameObject wall)
        {
            if (wallPool.Count > 0)
            {
                wall = wallPool.Dequeue();
                wall.SetActive(true);
                return wall;
                
            }
            else
            {
                return null;
            }
        }

        private void ReturnWallToPool(GameObject wall)
        {
            wall.SetActive(false);
            wallPool.Enqueue(wall);
        }
        
        
        
        
    }
}