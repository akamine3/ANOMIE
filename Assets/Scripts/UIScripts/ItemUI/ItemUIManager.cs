using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    [Header("ScrollView�Ǘ�")]
    [SerializeField] private ScrollViewSwitcher m_switcher;
    [SerializeField] private GameObject m_itemSlotPrefab;

    [Header("�f�[�^�Q��")]
    [SerializeField] private ItemDataBase m_itemDatabase;
    [SerializeField] private PlayerInventory m_playerInventory;

    private Transform m_currentContentParent;
    private Dictionary<string, ItemSlotUI> m_spawnedSlots = new();

    private void Start()
    {
        // �C�x���g�o�^
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged += OnInventoryChanged;

        // �����\��
        OnInventoryChanged();
    }

    private void OnDestroy()
    {
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged -= OnInventoryChanged;
    }

    /// <summary>
    /// �C���x���g���ύX����UI�X�V
    /// </summary>
    private void OnInventoryChanged()
    {
        // ����́u�ʏ�A�C�e���v�^�u�̂ݕ\���i�K�v�ɉ����Đ؂�ւ��j
        Debug.Log("[UI] OnInventoryChanged() �Ă΂ꂽ");
        RefreshUI(ItemDataBase.ItemData.ItemType.Quest);
    }

    /// <summary>
    /// UI���X�V�i�����ǉ������{��`�F�b�N�j
    /// </summary>
    public void RefreshUI(ItemDataBase.ItemData.ItemType type)
    {
        m_switcher.Show(type);
        m_currentContentParent = m_switcher.GetCurrentContent();

        // ���݂̏����A�C�e���ꗗ���擾
        var ownedItems = m_playerInventory.GetAllItems();
        if (ownedItems == null || ownedItems.Count == 0)
        {
            Debug.Log("[UI] �A�C�e�����������Ă��܂���");
            // ����UI���폜���Ă����i��\���j
            foreach (Transform child in m_currentContentParent)
                Destroy(child.gameObject);
            m_spawnedSlots.Clear();
            return;
        }

        // �����A�C�e���Ɋ�Â���UI���X�V
        foreach (var owned in ownedItems)
        {
            // �}�X�^�[����Y���A�C�e��������
            var data = m_itemDatabase.ItemList.Find(i => i.ItemId == owned.ItemId && i.Type == type);
            if (data == null) continue; // ���J�e�S���̓X�L�b�v

            // ���ɕ\���ς݂��H
            if (m_spawnedSlots.ContainsKey(owned.ItemId))
            {
                m_spawnedSlots[owned.ItemId].UpdateUI();
                continue;
            }

            // �V�K�A�C�e���̏ꍇ �� �X���b�g����
            var slotObj = Instantiate(m_itemSlotPrefab, m_currentContentParent);
            slotObj.name = owned.ItemId;
            var slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetItemId(owned.ItemId);

            m_spawnedSlots.Add(owned.ItemId, slotUI);
        }
    }
}
