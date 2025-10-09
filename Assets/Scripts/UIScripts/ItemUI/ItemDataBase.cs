using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ItemDatabase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> ItemList = new List<ItemData>();

    [System.Serializable]
    public class ItemData
    {
        [SerializeField, Tooltip("アイテムID")] private string m_itemId;
        [SerializeField, Tooltip("アイテム名")] private string m_itemName;
        [SerializeField, Tooltip("アイテムの分類\nNone: 付与効果なし\nPassive: 常時効果アイテム\nActive: 消耗品")] private ItemType m_type;
        [SerializeField, Tooltip("アイコン画像")] private Sprite m_icon;
        [SerializeField, TextArea, Tooltip("説明テキスト")] private string m_description;

        public enum ItemType 
        {
            None,
            Passive,
            Active
        }

        public string ItemId => m_itemId;
        public string ItemName => m_itemName;
        public Sprite Icon => m_icon;
        public ItemType Type => m_type;
        public string Description => m_description;
    }

}
