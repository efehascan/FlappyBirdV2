using System.Collections;
using Flappybird.Scripts.SingletonPattern;
using UnityEngine;


namespace Flappybird.Scripts.Wall
{
    public class WallManager : MonoBehaviourSingleton<WallManager>
    {
        [SerializeField] public GameObject wallPrefab;
        [SerializeField] private float spawnXOffset = 15;
        
        private Coroutine spawnCoroutine;
        private readonly WaitForSeconds spawnRoutine = new WaitForSeconds(2.5f);
        

        private void Start()
        {
            WallPool.Instance.CreateWallPool();

            spawnCoroutine = StartCoroutine(StartSpawnCoroutine());
        }

        

        private void SpawnWall()
        {
            GameObject wall = WallPool.Instance.GetWallFromPool();
            
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
            
            
            WallPool.Instance.ReturnWallToPool(wall);
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