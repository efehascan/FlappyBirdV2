using Flappybird.Scripts.Gameplay.Coins;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.UI.InGame
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        

        private void OnEnable()
        {
            CoinManager.OnCoinValueChanged += CoinManager_OnCoinValueChanged;
        }

        private void CoinManager_OnCoinValueChanged()
        {
            coinText.text = "Coin: " + CoinManager.Instance.runCoinValue.ToString();
        }

        private void OnDestroy()
        {
            CoinManager.OnCoinValueChanged -= CoinManager_OnCoinValueChanged;
        }
    }
}