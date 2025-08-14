using UnityEngine;

namespace Flappybird.Scripts.Coin
{
    public class Gold : MonoBehaviour,  ICollectible
    {
        public void CollectCoin()
        {
            CoinManager.Instance.AddCoin(50);
        }
    }
}