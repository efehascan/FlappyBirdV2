using System.Collections;
using Flappybird.Scripts.SingletonPattern;
using UnityEngine;


namespace Flappybird.Scripts.Wall
{
    public class WallManager : MonoBehaviourSingleton<WallManager>
    {
        [SerializeField] public GameObject wallPrefab;
        [SerializeField] private float spawnXOffset = 15;
        [SerializeField] private float spawnMaxYOffset = 4.5f;
        [SerializeField] private float spawnMinYOffset = -2.5f;
        [SerializeField] private bool isSpawning = false;
        
        private Coroutine spawnCoroutine;
        private readonly WaitForSeconds spawnRoutine = new WaitForSeconds(2.5f);
        

        private void Start()
        {
            isSpawning = true;
            spawnCoroutine = StartCoroutine(StartSpawnCoroutine());
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


        private IEnumerator StartSpawnCoroutine()
        {
            while (isSpawning)
            {
                SpawnWall();

                yield return spawnRoutine;
            }
        }


        #region On Destroy & On Disable
        
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
        #endregion

    }
}
