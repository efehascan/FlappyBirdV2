using Flappybird.Scripts.Core.Patterns;
using Flappybird.Scripts.Core.Services;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.UI.MainMenu
{
    public class WalletUIManager : MonoBehaviourSingleton<WalletUIManager>
    {
        [SerializeField] private TMP_Text walletText;

        private void Start()
        {
            RefreshWallet();
        }

        public void RefreshWallet()
        {
            walletText.text = "Wallet: " + FileSaveManager.Instance.GetWallet();
        }
    }
}