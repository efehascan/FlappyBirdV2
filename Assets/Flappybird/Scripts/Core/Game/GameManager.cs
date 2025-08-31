using Flappybird.Scripts.Core.Patterns;
using Flappybird.Scripts.Core.Services;
using Flappybird.Scripts.Gameplay.Coins;
using Flappybird.Scripts.Gameplay.Points;
using Flappybird.Scripts.Gameplay.Walls;
using Flappybird.Scripts.UI.InGame;
using UnityEngine;

namespace Flappybird.Scripts.Core.Game
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