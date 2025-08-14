using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class Silver : MonoBehaviour,  ICollectible
    {
        public void CollectCoin()
        {
            CoinManager.Instance.AddCoin(10);
        }
    }
}