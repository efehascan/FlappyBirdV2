using System;
using Flappybird.Scripts.Coin;
using Flappybird.Scripts.ObserverPattern;
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
    }
}