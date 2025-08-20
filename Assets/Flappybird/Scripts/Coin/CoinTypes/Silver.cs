using UnityEngine;

namespace Flappybird.Scripts.Coin.CoinTypes
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