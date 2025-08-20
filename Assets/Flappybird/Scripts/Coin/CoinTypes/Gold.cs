using UnityEngine;

namespace Flappybird.Scripts.Coin.CoinTypes
{
    public class Gold : MonoBehaviour,  ICollectible
    {
        public void CollectCoin()
        {
            CoinManager.Instance.AddCoin(50);
            CoinManager.Instance.DespawnCoin(this.gameObject);
        }
        
    }
}