using System;
using UnityEngine;

namespace Flappybird.Scripts.Point
{
    public class PointArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            PointManager.Instance.UpdateScore();
        }
    }
}