using Flappybird.Scripts.UI.MainMenu;
using UnityEngine;

namespace Flappybird.Scripts.UI.Shop
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private SkinDatabase database;
        [SerializeField] private Transform contentParent;
        [SerializeField] private SkinButton skinButtonPrefab;
        
        private void OnEnable()
        {
            Rebuild();
            SkinManager.Instance.onPurchased += _ => Rebuild();
            SkinManager.Instance.onEquippedChanged += _ => Rebuild();
        }

        private void OnDisable()
        {
            if (SkinManager.Instance == null) return;
            SkinManager.Instance.onPurchased -= _ => Rebuild();
            SkinManager.Instance.onEquippedChanged -= _ => Rebuild();
        }

        private void Rebuild()
        {
            WalletUIManager.Instance.RefreshWallet();
            
            foreach (Transform t in contentParent) 
                Destroy(t.gameObject);
            foreach (var item in database.Items)
                Instantiate(skinButtonPrefab, contentParent).Bind(item);
        }
        
    }
}