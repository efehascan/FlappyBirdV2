using System;
using Flappybird.Scripts.Core.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Scripts.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerManager : MonoBehaviourSingletonPersistent<PlayerManager>
    {
        private Rigidbody2D rb;
        private Vector3 startPosition;

        public override void Awake()
        {
            base.Awake();
            rb = GetComponent<Rigidbody2D>();
            
            startPosition = transform.position;
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex == 1)
            {
                rb.constraints = RigidbodyConstraints2D.None;
            }else if (scene.buildIndex == 0)
            {
                // Ana menüde başlangıç noktasına dön
                transform.position = startPosition;
                rb.velocity = Vector2.zero;        // hareket varsa sıfırla
                rb.angularVelocity = 0f;           // dönme hızını sıfırla

                // Hiç hareket etmesin (pozisyon + rotasyon tamamen kitli)
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            
            
        }
    }
}