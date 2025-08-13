using Flappybird.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.Coin
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
            coinText.text = "Coin: " + CoinManager.Instance.coinValue.ToString();
        }

        private void OnDestroy()
        {
            CoinManager.OnCoinValueChanged -= CoinManager_OnCoinValueChanged;
        }
    }
}