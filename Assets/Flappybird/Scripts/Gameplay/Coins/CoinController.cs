using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 3.5f;
        
        private void FixedUpdate()
        {
            MoveCoin();
        }


        private void MoveCoin()
        {
            transform.position += Vector3.left * (movementSpeed * Time.deltaTime);
        }
    }
}