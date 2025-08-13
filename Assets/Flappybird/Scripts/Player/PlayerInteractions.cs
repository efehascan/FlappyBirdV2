using System;
using Flappybird.Scripts.ObserverPattern;
using UnityEngine;

namespace Flappybird.Scripts.Player
{
    public class PlayerInteractions : MonoBehaviour
    {
        private const string Coin = "Coin";
        
        public static Action OnCoinCollected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Coin))
            {
                OnCoinCollected?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}