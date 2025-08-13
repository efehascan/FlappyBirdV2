using System;
using Flappybird.Scripts.ObserverPattern;
using UnityEngine;

namespace Flappybird.Scripts.Player
{
    public class PlayerInteraction : Subject
    {
        private const string Coin = "Coin";

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Coin))
            {
                NotifyObservers();
                Destroy(other.gameObject);
            }
        }
    }
}