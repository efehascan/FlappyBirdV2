using Flappybird.Scripts.Coin;
using Flappybird.Scripts.Point;
using Flappybird.Scripts.SingletonPattern;
using Flappybird.Scripts.Wall;
using Flappybird.Scripts.Wallet;
using UnityEngine;

namespace Flappybird.Scripts.Managers.InGame
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [SerializeField] private Transform finishMenu;
        [SerializeField] private Transform coins;
        [SerializeField] private Transform walls;
        
        public void EndGame()
        {
            //coins.gameObject.SetActive(false);
            //walls.gameObject.SetActive(false);
            
            finishMenu.gameObject.SetActive(true);
            FinishMenuManager.Instance.RefreshText();
            
            
            CoinManager.Instance.CancelInvoke(nameof(CoinManager.SpawnCoin));
            foreach (Transform child in coins)
            {
                if (child) child.gameObject.SetActive(false);
            }
            
            WallManager.Instance.CancelInvoke(nameof(WallManager.SpawnWall));
            WallPool.Instance.wallPool.ForEach(wall => wall.SetActive(false));

            PointManager.Instance.SubmitScore();
            
            WalletService.Instance.AddCoinToWallet(CoinManager.Instance.runCoinValue);
            
        }
    }
}