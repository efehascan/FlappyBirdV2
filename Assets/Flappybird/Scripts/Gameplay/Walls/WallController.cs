using UnityEngine;

namespace Flappybird.Scripts.Gameplay.Walls
{
    public class WallController : MonoBehaviour
    {
        
        [SerializeField] private float movementSpeed = 3.5f;
        

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