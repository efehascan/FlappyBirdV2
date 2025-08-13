using System;
using UnityEngine;

namespace Flappybird.Scripts.Player
{
    
    [RequireComponent((typeof(Rigidbody2D)))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float verticalSpeed;
        [SerializeField] private float rotationSpeed;
        
        private Rigidbody2D rb2d;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            VerticalMovement();
        }


        private void VerticalMovement()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                rb2d.velocity = Vector2.up * verticalSpeed;
            }
            
            transform.rotation = Quaternion.Euler(0, 0, rb2d.velocity.y * rotationSpeed);
        }


    }
}