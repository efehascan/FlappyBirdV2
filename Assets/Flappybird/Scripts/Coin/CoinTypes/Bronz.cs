using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class Bronz : MonoBehaviour,  ICollectible
    {
        public void CollectCoin()
        {
            CoinManager.Instance.AddCoin(1);
        }
    }
}