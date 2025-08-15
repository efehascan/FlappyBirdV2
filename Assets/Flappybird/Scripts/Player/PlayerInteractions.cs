using System;
using Flappybird.Scripts.Coin;
using Flappybird.Scripts.ObserverPattern;
using UnityEngine;

namespace Flappybird.Scripts.Player
{
    public class PlayerInteractions : MonoBehaviour
    {
        
        private const string Coin = "Coin";

        private void OnTriggerEnter2D(Collider2D other)
        {
            ICollectible collectible = other.GetComponent<ICollectible>();
            
            if (other.gameObject.CompareTag(Coin))
            {
                collectible.CollectCoin();
            }
        }
    }
}