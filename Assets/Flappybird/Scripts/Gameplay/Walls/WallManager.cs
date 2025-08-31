using System.Collections.Generic;
using Flappybird.Scripts.Core.Patterns;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Flappybird.Scripts.Gameplay.Walls
{
    public class WallManager : MonoBehaviourSingleton<WallManager>
    {
        [SerializeField] public GameObject wallPrefab;
        [SerializeField] private float spawnXOffset = 15;
        [SerializeField] private float spawnMaxYOffset = 4.5f;
        [SerializeField] private float spawnMinYOffset = -2.5f;
        [SerializeField] private float spawnInterval = 2.5f;
        
        public List<GameObject> activeWalls;
        

        private void Awake()
        {
            WallPool.Instance.CreateWallPool();
            
            InvokeRepeating(nameof(SpawnWall), 0f, spawnInterval);
        }


        public void SpawnWall()
        {
            GameObject wall = WallPool.Instance.GetWallFromPool();
            activeWalls.Add(wall);
            
            if (wall == null)
                return;
            
            Vector3 spawnPosition = new Vector3(spawnXOffset, Random.Range(spawnMinYOffset, spawnMaxYOffset), 0);
            
            wall.transform.position = spawnPosition;
        }


        public void DespawnWall(GameObject wall)
        {
            activeWalls.Remove(wall);
            WallPool.Instance.ReturnWallToPool(wall);
        }


        private void OnDisable()
        {
            CancelInvoke(nameof(SpawnWall));
        }
    }
}
