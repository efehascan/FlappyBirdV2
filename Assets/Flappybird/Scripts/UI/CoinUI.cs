using System;
using Flappybird.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.UI
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;

        private int coinCount;

        private void OnEnable()
        {
            PlayerInteractions.OnCoinCollected += PlayerInteraction_OnCoinCollected;
        }

        private void PlayerInteraction_OnCoinCollected()
        {
            coinCount++;
            coinText.text = "Coin: " + coinCount.ToString();
        }

        private void OnDestroy()
        {
            PlayerInteractions.OnCoinCollected -= PlayerInteraction_OnCoinCollected;
        }
    }
}