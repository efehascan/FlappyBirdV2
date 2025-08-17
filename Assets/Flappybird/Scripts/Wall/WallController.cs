using System;
using UnityEngine;

namespace Flappybird.Scripts.Wall
{
    public class WallController : MonoBehaviour
    {
        
        [SerializeField] private float movementSpeed = 3.5f;
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == Camera.main.gameObject)
            {
                WallManager.Instance.DespawnWall(this.gameObject);
            }
            
        }

        private void FixedUpdate()
        {
            MoveWall();
        }


        private void MoveWall()
        {
            transform.position += Vector3.left * (movementSpeed * Time.deltaTime);
        }
    }
}