using System;
using TMPro;
using UnityEngine;

namespace Flappybird.Scripts.Managers.MainMenu
{
    public class WalletUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text walletText;

        private void Start()
        {
            walletText.text = "Wallet: " + FileSaveManager.Instance.GetWallet();
        }
    }
}