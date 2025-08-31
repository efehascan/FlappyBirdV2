using Flappybird.Scripts.Core.Game;
using Flappybird.Scripts.Gameplay.Coins.Interfaces;
using Flappybird.Scripts.Gameplay.Walls;
using UnityEngine;

namespace Flappybird.Scripts.Gameplay.Player
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