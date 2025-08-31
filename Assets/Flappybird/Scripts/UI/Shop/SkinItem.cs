using UnityEngine;

namespace Flappybird.Scripts.UI.Shop
{
    [CreateAssetMenu(fileName = "SkinItem", menuName = "Game/Skin Item")]
    public class SkinItem : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private string displayName;
        [SerializeField] private int price;
        [Header("Visual")]
        [SerializeField] private Sprite sprite;
        [SerializeField] private RuntimeAnimatorController animatorOverride;

        public string Id => id;
        public string DisplayName => displayName;
        public int Price => price;
        public Sprite Sprite => sprite;
        public RuntimeAnimatorController AnimatorOverride => animatorOverride;
        
    }
} 