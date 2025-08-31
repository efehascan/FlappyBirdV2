using UnityEngine;

namespace Flappybird.Scripts.Gameplay.Player
{
    
    [RequireComponent((typeof(Rigidbody2D)))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float verticalSpeed;
        [SerializeField] private float rotationSpeed;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            VerticalMovement();
        }


        private void VerticalMovement()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                _rigidbody2D.velocity = Vector2.up * verticalSpeed;
            }
            
            transform.rotation = Quaternion.Euler(0, 0, _rigidbody2D.velocity.y * rotationSpeed);
        }


    }
}