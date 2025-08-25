using System;
using Flappybird.Scripts.Coin;
using Flappybird.Scripts.Managers.InGame;
using Flappybird.Scripts.ObserverPattern;
using Flappybird.Scripts.Wall;
using UnityEngine;

namespace Flappybird.Scripts.Player
{
    public class PlayerInteractions : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.TryGetComponent<ICollectible>(out var collectible))
            {
                collectible.CollectCoin();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<WallController>(out var wallController))
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}