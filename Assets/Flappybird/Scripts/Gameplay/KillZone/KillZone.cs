using System;
using Flappybird.Scripts.Coin;
using Flappybird.Scripts.Wall;
using UnityEngine;

namespace Flappybird.Scripts.KillZone
{
    public class KillZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<WallController>(out WallController wall))
            {
                WallManager.Instance.DespawnWall(other.gameObject);
            } 
            else if (other.TryGetComponent<CoinController>(out CoinController coin))
            {
                CoinManager.Instance.DespawnCoin(other.gameObject);
            }

        }
    }
}