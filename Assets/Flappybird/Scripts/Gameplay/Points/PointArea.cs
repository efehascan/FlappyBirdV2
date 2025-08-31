using UnityEngine;

namespace Flappybird.Scripts.Gameplay.Points
{
    public class PointArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            PointManager.Instance.UpdateScore();
        }
    }
}