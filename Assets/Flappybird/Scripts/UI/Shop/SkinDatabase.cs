using UnityEngine;

namespace Flappybird.Scripts.UI.Shop
{
    [CreateAssetMenu(fileName = "SkinDatabase", menuName = "Game/Skin Database")]
    public class SkinDatabase : ScriptableObject
    {
        [SerializeField] private SkinItem[] items;
        public SkinItem[] Items => items;

        public SkinItem Find(string id)
        {
            foreach (var s in items) if (s.Id == id) return s;
            return null;
        }
    }
}