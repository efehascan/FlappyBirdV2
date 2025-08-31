using Flappybird.Scripts.Wall;
using UnityEngine;

namespace Flappybird.Scripts.Coin.CoinTypes
{
    public class Bronz : MonoBehaviour,  ICollectible
    {
        public void CollectCoin()
        {
            CoinManager.Instance.AddCoin(1);
            CoinManager.Instance.DespawnCoin(this.gameObject);
        }
    }
}