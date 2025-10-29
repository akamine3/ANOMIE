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

    [Header("�A�C�e���ڍ׃p�l��")]
    [SerializeField] private ItemDetailUI m_detailUI;

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

        // �A�C�e���ڍ׃p�l���ݒ�
        if (m_detailUI != null)
            m_detailUI.Initialize(m_itemDatabase);

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
        StartCoroutine(RefreshUICoroutine(type));
    }

    private IEnumerator RefreshUICoroutine(ItemDataBase.ItemData.ItemType type)
    {
        // �^�u��؂�ւ�
        m_switcher.Show(type);
        yield return null; // 1�t���[���ҋ@

        m_currentContentParent = m_switcher.GetCurrentContent();
        if (m_currentContentParent == null)
        {
            Debug.LogError($"[UI] Content��������܂���: {type}");
            yield break;
        }

        // �SNoItems����U��\��
        if (m_noItemQuest) m_noItemQuest.SetActive(false);
        if (m_noItemConsumable) m_noItemConsumable.SetActive(false);
        if (m_noItemPassive) m_noItemPassive.SetActive(false);

        // �����A�C�e���ꗗ
        var ownedItems = m_playerInventory?.GetAllItems();
        if (ownedItems == null) yield break;

        // �X���b�g�폜
        foreach (Transform child in m_currentContentParent)
            Destroy(child.gameObject);
        m_spawnedSlots.Clear();

        // �Ώۃ^�C�v�̒��o
        var itemsOfType = ownedItems
            .Where(i => i != null &&
                        m_itemDatabase.ItemList.Any(d => d.ItemId == i.ItemId && d.Type == type))
            .ToList();

        Debug.Log($"[UI] {type} �^�C�v�̏�����: {itemsOfType.Count}");

        bool hasAny = itemsOfType.Count > 0;

        // NoItems�\������i�ėL�����j
        switch (type)
        {
            case ItemDataBase.ItemData.ItemType.Quest:
                if (m_noItemQuest) m_noItemQuest.SetActive(!hasAny);
                break;
            case ItemDataBase.ItemData.ItemType.Active:
                if (m_noItemConsumable) m_noItemConsumable.SetActive(!hasAny);
                break;
            case ItemDataBase.ItemData.ItemType.Passive:
                if (m_noItemPassive) m_noItemPassive.SetActive(!hasAny);
                break;
        }

        if (!hasAny)
        {
            Debug.Log($"[UI] {type} �ɑ�����A�C�e���Ȃ� �� NoItems�\��");
            yield break;
        }

        // �X���b�g����
        foreach (var owned in itemsOfType)
        {
            var data = m_itemDatabase.ItemList.Find(i => i.ItemId == owned.ItemId && i.Type == type);
            if (data == null) continue;

            var slotObj = Instantiate(m_itemSlotPrefab, m_currentContentParent);
            slotObj.name = owned.ItemId;
            var slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetItemId(owned.ItemId);
            m_spawnedSlots.Add(owned.ItemId, slotUI);
        }

        Debug.Log($"[UI] {type} �̃X���b�g��������: {m_spawnedSlots.Count}��");
    }

    /// <summary>
    /// UI�{�^������Ăяo��: �^�u�؂�ւ�
    /// </summary>
    public void ChangeTab(ItemDataBase.ItemData.ItemType type)
    {
        Debug.Log($"[ItemUIManager] �^�u�؂�ւ�: {type}");
        RefreshUI(type);
    }


    public void OnItemSelected(string itemId)
    {
        Debug.Log($"[ItemUIManager] �I���A�C�e��: {itemId}");
        if (m_detailUI != null)
            m_detailUI.ShowItem(itemId);
    }
}
