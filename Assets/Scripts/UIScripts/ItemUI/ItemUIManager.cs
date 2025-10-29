using System.Collections;
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

    [Header("NoItems �\���e�L�X�g")]
    [SerializeField] private GameObject m_noItemQuest;
    [SerializeField] private GameObject m_noItemConsumable;
    [SerializeField] private GameObject m_noItemPassive;

    private Transform m_currentContentParent;
    private Dictionary<string, ItemSlotUI> m_spawnedSlots = new();


    private void Awake()
    {
        Debug.Log($"[ItemUIManager] Prefab status: {m_itemSlotPrefab} ({m_itemSlotPrefab?.scene.name})");
    }

    private void Start()
    {
        if (m_itemSlotPrefab == null)
            Debug.LogError("[ItemUIManager] Item Slot Prefab �����s���� Missing �ł��BPrefab �Q�Ƃ����Ă��܂��B");
        else
            Debug.Log($"[ItemUIManager] Prefab OK: {m_itemSlotPrefab.name}");

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
        int count = m_playerInventory?.GetEventListenerCount() ?? 0;
        Debug.Log($"[UI] OnInventoryChanged���Ă΂ꂽ (�o�^��: {count})");

        // ���݂̕\���^�u�̃J�e�S���̂ݍX�V
        var currentType = m_switcher.GetCurrentType();
        RefreshUI(currentType);
    }


    private IEnumerator RefreshAfterClear()
    {
        yield return null; // 1�t���[���҂�
        foreach (ItemDataBase.ItemData.ItemType type in System.Enum.GetValues(typeof(ItemDataBase.ItemData.ItemType)))
        {
            RefreshUI(type);
        }
    }

    /// <summary>
    /// UI���X�V
    /// </summary>
    public void RefreshUI(ItemDataBase.ItemData.ItemType type)
    {
        // ���̃^�u��\�����AContent���擾
        m_switcher.Show(type);
        m_currentContentParent = m_switcher.GetCurrentContent();
        if (m_currentContentParent == null)
        {
            Debug.LogError("[UI] Content��������܂���");
            return;
        }

        // �����A�C�e�����J�e�S����������>0�Ō����ɒ��o
        var ownedItems = m_playerInventory?.GetAllItems();
        var filtered = (ownedItems == null)
            ? new List<PlayerItemStatus>()
            : ownedItems.Where(i =>
                  i != null && i.PossessionCount > 0 &&
                  m_itemDatabase.ItemList.Any(d => d.ItemId == i.ItemId && d.Type == type)
              ).ToList();

        // �܂������X���b�g��S�폜
        foreach (Transform child in m_currentContentParent)
            Destroy(child.gameObject);
        m_spawnedSlots.Clear();

        // NoItems�e�L�X�g�͖���u�S��OFF�v���K�v�Ȃ�Ώۂ̂�ON
        if (m_noItemQuest) m_noItemQuest.SetActive(false);
        if (m_noItemConsumable) m_noItemConsumable.SetActive(false);
        if (m_noItemPassive) m_noItemPassive.SetActive(false);

        // ��Ȃ�A�Y���^�u��NoItems����ON�ɂ��ďI��
        if (filtered.Count == 0)
        {
            switch (type)
            {
                case ItemDataBase.ItemData.ItemType.Quest:
                    if (m_playerInventory.ItemStatuses.Count(
                        i => m_itemDatabase.ItemList.Any(d => d.Type == ItemDataBase.ItemData.ItemType.Quest)) < 0) 
                        m_noItemQuest.SetActive(true);
                    break;
                case ItemDataBase.ItemData.ItemType.Active:
                    if (m_playerInventory.ItemStatuses.Count(
                        i => m_itemDatabase.ItemList.Any(d => d.Type == ItemDataBase.ItemData.ItemType.Active)) < 0)
                        m_noItemConsumable.SetActive(true);
                    break;
                case ItemDataBase.ItemData.ItemType.Passive:
                    if (m_playerInventory.ItemStatuses.Count(
                        i => m_itemDatabase.ItemList.Any(d => d.Type == ItemDataBase.ItemData.ItemType.Passive)) < 0)
                        m_noItemPassive.SetActive(true); 
                    break;
            }

            Debug.Log($"[UI] NoItems�\��: type={type}, filtered=0");
            return;
        }

        // �X���b�g�����ifiltered�����j
        foreach (var owned in filtered)
        {
            var slotObj = Instantiate(m_itemSlotPrefab, m_currentContentParent);
            slotObj.name = owned.ItemId;
            var slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetItemId(owned.ItemId);
            m_spawnedSlots[owned.ItemId] = slotUI;
        }

        // �����ł����̂ŊY��NoItems�͕K��OFF�i�ی��j
        switch (type)
        {
            case ItemDataBase.ItemData.ItemType.Quest:
                if (m_noItemQuest) m_noItemQuest.SetActive(false);
                break;
            case ItemDataBase.ItemData.ItemType.Active:
                if (m_noItemConsumable) m_noItemConsumable.SetActive(false);
                break;
            case ItemDataBase.ItemData.ItemType.Passive:
                if (m_noItemPassive) m_noItemPassive.SetActive(false);
                break;
        }

        Debug.Log($"[UI] ��������: type={type}, filtered={filtered.Count}, slots={m_spawnedSlots.Count}");
    }


    /// <summary>
    /// UI�{�^������Ăяo��: �^�u�؂�ւ�
    /// </summary>
    public void ChangeTab(ItemDataBase.ItemData.ItemType type)
    {
        Debug.Log($"[ItemUIManager] �^�u�؂�ւ�: {type}");
        RefreshUI(type);
    }

}
