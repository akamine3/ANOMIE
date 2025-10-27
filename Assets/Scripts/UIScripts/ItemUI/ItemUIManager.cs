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
        Debug.Log($"[UI] OnInventoryChanged() �Ă΂ꂽ (�o�^��: {count})");

        //Debug.Log("[UI] OnInventoryChanged() �Ă΂ꂽ");

        foreach (ItemDataBase.ItemData.ItemType type in System.Enum.GetValues(typeof(ItemDataBase.ItemData.ItemType)))
        {
            StartCoroutine(RefreshAfterClear());
        }
        /*        // ���ݕ\�����Ă���^�u�̃^�C�v���擾
                var currentType = m_switcher.GetCurrentType();

                // ���݂̃^�u�ɔ��f
                RefreshUI(currentType);

                // ���C�A�E�g�����X�V
                Canvas.ForceUpdateCanvases();*/
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
    /// UI���X�V�i�����ǉ������{��`�F�b�N�j
    /// </summary>
    public void RefreshUI(ItemDataBase.ItemData.ItemType type)
    {
        // �Ώ�ScrollView��\��
        m_switcher.Show(type);

        // ���݂�Content Transform���擾�i������j
        m_currentContentParent = m_switcher.GetCurrentContent();
        if (m_currentContentParent == null)
        {
            Debug.LogError("[UI] Content ���擾�ł��܂���ł����BScrollView �̍\�����m�F���Ă��������B");
            return;
        }

        // �����A�C�e�����擾
        var ownedItems = m_playerInventory.GetAllItems();
        if (ownedItems == null || ownedItems.Count == 0)
        {
            Debug.Log("[UI] �A�C�e�����������Ă��܂���");

            foreach (Transform child in m_currentContentParent)
            {
                Destroy(child.gameObject);
            }
            m_spawnedSlots.Clear();
            return;
        }

        // �X���b�g����
        foreach (var owned in ownedItems)
        {
            var data = m_itemDatabase.ItemList.Find(i => i.ItemId == owned.ItemId && i.Type == type);
            if (data == null) continue;

            if (m_spawnedSlots.ContainsKey(owned.ItemId))
            {
                m_spawnedSlots[owned.ItemId].UpdateUI();
                continue;
            }

            // �������d�v�F������� m_currentContentParent �ɕύX
            var slotObj = Instantiate(m_itemSlotPrefab, m_currentContentParent);
            slotObj.name = owned.ItemId;

            var slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetItemId(owned.ItemId);

            m_spawnedSlots.Add(owned.ItemId, slotUI);
        }

        // ���C�A�E�g�X�V
        Canvas.ForceUpdateCanvases();
    }

}
