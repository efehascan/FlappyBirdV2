using System;
using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class CoinMovement : MonoBehaviour
    {
        private float movementSpeed = 3.5f;

        private void Update()
        {
            MoveCoin();
        }


        private void MoveCoin()
        {
            transform.position += Vector3.left * (movementSpeed * Time.deltaTime);
        }
        
    }
}