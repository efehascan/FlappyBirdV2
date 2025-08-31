using Flappybird.Scripts.Gameplay.Coins.Interfaces;
using UnityEngine;

namespace Flappybird.Scripts.Gameplay.Coins.Types
{
    public class Silver : MonoBehaviour,  ICollectible
    {
        public void CollectCoin()
        {
            CoinManager.Instance.AddCoin(10);
            CoinManager.Instance.DespawnCoin(this.gameObject);
        }
        
    }
}