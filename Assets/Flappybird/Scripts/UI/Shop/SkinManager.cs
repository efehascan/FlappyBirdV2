using System;
using Flappybird.Scripts.Core.Patterns;
using Flappybird.Scripts.Core.Services;
using UnityEngine;

namespace Flappybird.Scripts.UI.Shop
{
    public class SkinManager : MonoBehaviourSingleton<SkinManager>
    {
        [Header("Data")] 
        [SerializeField] private SkinDatabase database;

        [Header("Targer Renderers")] 
        [SerializeField] private SpriteRenderer targetSprite;
        [SerializeField] private Animator targetAnimator;
        
        public event Action<string> onEquippedChanged;
        public event Action<string> onPurchased;
        
        private FileSaveManager Save => FileSaveManager.Instance;

        private void Awake()
        {
            
        }

        private void Start()
        {
            
        }
        
        private void EnsureDefaultOwned()
        {
            var def = database.Find("default");
            if (def != null && !Save.IsSkinOwned(def.Id))
            {
                Save.SetSkinOwned(def.Id, true);
            }

            var equipped = Save.GetEquippedSkin();
            if (string.IsNullOrEmpty(equipped))
            {
                Save.SetEquippedSkin(def != null ? def.Id : "default");
            }
        }

        public bool IsOwned(string id) => Save.IsSkinOwned(id);
        public string EquippedId => Save.GetEquippedSkin();
        
        public bool BuySkin(string id)
        {
            var item = database.Find(id);
            if (!item) 
                return false;         // geçersiz id
            if (IsOwned(id)) 
                return true;         // zaten sahip

            int wallet = Save.GetWallet();
            if (wallet < item.Price) 
                return false; // yetersiz coin

            Save.SetWallet(wallet - item.Price);
            Save.SetSkinOwned(id, true);
            onPurchased?.Invoke(id);
            return true;
        }
        
        public bool EquipSkin(string id)
        {
            if (!IsOwned(id)) return false;

            Save.SetEquippedSkin(id);
            ApplyEquipped();
            onEquippedChanged?.Invoke(id);
            return true;
        }
        
        public void ApplyEquipped()
        {
            var equippedId = Save.GetEquippedSkin();
            var item = database.Find(equippedId);
            if (!item) return;

            if (targetSprite && item.Sprite)
                targetSprite.sprite = item.Sprite;

            if (targetAnimator && item.AnimatorOverride)
                targetAnimator.runtimeAnimatorController = item.AnimatorOverride;
        }
        
        
        
    }
}