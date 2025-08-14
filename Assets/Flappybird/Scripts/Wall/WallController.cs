using System;
using UnityEngine;

namespace Flappybird.Scripts.Wall
{
    public class WallController : MonoBehaviour
    {
        private const string Camera = "MainCamera";
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Camera))
            {
                WallManager.Instance.DespawnWall(this.gameObject);
            }
            
        }
    }
}