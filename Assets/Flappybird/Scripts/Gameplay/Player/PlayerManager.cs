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

        public override void Awake()
        {
            base.Awake();
            rb = GetComponent<Rigidbody2D>();
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
            }
        }
    }
}