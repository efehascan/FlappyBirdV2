using System;
using UnityEngine;

namespace Flappybird.Scripts.Wall
{
    public class WallMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 2f;
        


        private void Update()
        {
            MoveWall();
        }


        private void MoveWall()
        {
            transform.position += Vector3.left * (movementSpeed * Time.deltaTime);
        }
    }
}