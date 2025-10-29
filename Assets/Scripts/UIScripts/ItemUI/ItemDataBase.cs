using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ItemDatabase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> ItemList = new List<ItemData>();

    // カテゴリ別に読み出すプロパティ（読み取り専用）
    public IEnumerable<ItemData> QuestItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Quest);
    public IEnumerable<ItemData> ConsumableItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Active);
    public IEnumerable<ItemData> PassiveItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Passive);


    [System.Serializable]
    public class ItemData
    {
        [SerializeField, Tooltip("アイテムID")] private string m_itemId;
        [SerializeField, Tooltip("アイテム名")] private string m_itemName;
        [SerializeField, Tooltip("[アイテムの分類]\n" +
            "Quest  : 付与効果なし\n" +
            "Passive: 常時効果アイテム\n" +
            "Active : 消耗品")] private ItemType m_type;
        [SerializeField, Tooltip("[使用タイプ]\n" +
            "None      : 使用できない\n" +
            "Once      : 一度きり\n" +
            "Repeatable: 何度でも使用できる\n" +
            "Passive   : 常時発動")] UseType m_useType;
        [SerializeField, Tooltip("アイコン画像")] private Sprite m_icon;
        [SerializeField, TextArea, Tooltip("説明テキスト")] private string m_description;

        public enum ItemType 
        {
            Quest = 0,
            Passive = 1,
            Active = 2
        }

        public enum UseType
        {
            None,        // 使用できない（純粋なキーアイテム）
            Once,        // 一度使うと消える（回復薬など）
            Repeatable,  // 何度でも使える（例：笛・スイッチ用アイテム）
            Passive      // 常時発動（使う操作なし）
        }


        public string ItemId => m_itemId;
        public string ItemName => m_itemName;
        public Sprite Icon => m_icon;
        public ItemType Type => m_type;
        public UseType UsageType => m_useType;
        public string Description => m_description;

    }


}
