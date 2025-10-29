using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ItemDatabase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> ItemList = new List<ItemData>();

    // �J�e�S���ʂɓǂݏo���v���p�e�B�i�ǂݎ���p�j
    public IEnumerable<ItemData> QuestItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Quest);
    public IEnumerable<ItemData> ConsumableItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Active);
    public IEnumerable<ItemData> PassiveItemList => ItemList.Where(i => i.Type == ItemData.ItemType.Passive);


    [System.Serializable]
    public class ItemData
    {
        [SerializeField, Tooltip("�A�C�e��ID")] private string m_itemId;
        [SerializeField, Tooltip("�A�C�e����")] private string m_itemName;
        [SerializeField, Tooltip("[�A�C�e���̕���]\n" +
            "Quest  : �t�^���ʂȂ�\n" +
            "Passive: �펞���ʃA�C�e��\n" +
            "Active : ���Օi")] private ItemType m_type;
        [SerializeField, Tooltip("[�g�p�^�C�v]\n" +
            "None      : �g�p�ł��Ȃ�\n" +
            "Once      : ��x����\n" +
            "Repeatable: ���x�ł��g�p�ł���\n" +
            "Passive   : �펞����")] UseType m_useType;
        [SerializeField, Tooltip("�A�C�R���摜")] private Sprite m_icon;
        [SerializeField, TextArea, Tooltip("�����e�L�X�g")] private string m_description;

        public enum ItemType 
        {
            Quest = 0,
            Passive = 1,
            Active = 2
        }

        public enum UseType
        {
            None,        // �g�p�ł��Ȃ��i�����ȃL�[�A�C�e���j
            Once,        // ��x�g���Ə�����i�񕜖�Ȃǁj
            Repeatable,  // ���x�ł��g����i��F�J�E�X�C�b�`�p�A�C�e���j
            Passive      // �펞�����i�g������Ȃ��j
        }


        public string ItemId => m_itemId;
        public string ItemName => m_itemName;
        public Sprite Icon => m_icon;
        public ItemType Type => m_type;
        public UseType UsageType => m_useType;
        public string Description => m_description;

    }


}
