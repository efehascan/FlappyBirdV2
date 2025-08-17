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
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == Camera.main.gameObject)
            {
                CoinManager.Instance.DespawnCoin(this.gameObject);
            }
            
        }
    }
}