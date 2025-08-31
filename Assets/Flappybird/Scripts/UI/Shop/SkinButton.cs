using Flappybird.Scripts.Core.Patterns;
using Flappybird.Scripts.Core.Services;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Flappybird.Scripts.UI.Shop
{
    public class SkinButton : MonoBehaviourSingleton<SkinButton>
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Button mainButton;
        [SerializeField] private TextMeshProUGUI buttonLabel;
        [SerializeField] private GameObject equippedBadge;
        
        private SkinItem skin;
        private FileSaveManager Save => FileSaveManager.Instance;
        
        public void Bind(SkinItem item)
        {
            skin = item;
            icon.sprite = item.Sprite;
            nameText.text = item.DisplayName;
            Refresh();
            mainButton.onClick.RemoveAllListeners();
            mainButton.onClick.AddListener(OnClick);
        }

        private void Refresh()
        {
            bool owned = SkinManager.Instance.IsOwned(skin.Id);
            bool equipped = SkinManager.Instance.EquippedId == skin.Id;

            equippedBadge.SetActive(equipped);

            if (!owned)
            {
                priceText.text = $"{skin.Price} coin";
                buttonLabel.text = "Satın Al";
                mainButton.interactable = Save.GetWallet() >= skin.Price;
            }
            else
            {
                priceText.text = "Sahip";
                buttonLabel.text = equipped ? "Takılı" : "Tak";
                mainButton.interactable = !equipped;
            }
        }

        private void OnClick()
        {
            if (!SkinManager.Instance.IsOwned(skin.Id))
                if (!SkinManager.Instance.BuySkin(skin.Id)) return;

            SkinManager.Instance.EquipSkin(skin.Id);
            Refresh();
        }
        
    }
}