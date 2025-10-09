using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ItemDatabase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> ItemList = new List<ItemData>();

    // �J�e�S���ʂɓǂݏo���v���p�e�B�i�ǂݎ���p�j
    public IEnumerable<ItemData> QuestItemList => ItemList.Where(i => i.Type == ItemData.ItemType.None);
    public IEnumerable<ItemData> ConsumableItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Active);
    public IEnumerable<ItemData> PassiveItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Passive);


    [System.Serializable]
    public class ItemData
    {
        [SerializeField, Tooltip("�A�C�e��ID")] private string m_itemId;
        [SerializeField, Tooltip("�A�C�e����")] private string m_itemName;
        [SerializeField, Tooltip("�A�C�e���̕���\nNone: �t�^���ʂȂ�\nPassive: �펞���ʃA�C�e��\nActive: ���Օi")] private ItemType m_type;
        [SerializeField, Tooltip("�A�C�R���摜")] private Sprite m_icon;
        [SerializeField, TextArea, Tooltip("�����e�L�X�g")] private string m_description;

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
