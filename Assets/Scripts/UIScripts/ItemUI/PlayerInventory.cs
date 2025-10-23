using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̏����A�C�e�����Ǘ�����N���X�B
/// UI����Ƃ͓Ɨ����A�f�[�^�݂̂������B
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    /// <summary>�����A�C�e���X�V�C�x���g</summary>
    public event Action OnInventoryChanged;

    [Header("���L�A�C�e���ꗗ")]
    [SerializeField] private List<PlayerItemStatus> m_itemStatuses = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// �A�C�e����ǉ�����i�����Ȃ���Z�j
    /// </summary>
    public void AddItem(string itemId, int amount)
    {
        if (string.IsNullOrEmpty(itemId) || amount <= 0) return;

        var item = m_itemStatuses.Find(i => i.ItemId == itemId);
        if (item == null)
        {
            m_itemStatuses.Add(new PlayerItemStatus(itemId, amount));
        }
        else
        {
            item.PossessionCount += amount;
        }

        Debug.Log($"[Inventory] {itemId} +{amount}�i���� {GetCount(itemId)}�j");
        OnInventoryChanged?.Invoke();
    }

    /// <summary>
    /// �A�C�e���������i�c�ʃ`�F�b�N����j
    /// </summary>
    public bool UseItem(string itemId, int amount = 1)
    {
        var item = m_itemStatuses.Find(i => i.ItemId == itemId);
        if (item == null || item.PossessionCount < amount)
        {
            Debug.LogWarning($"[Inventory] {itemId} �g�p���s�i�s���j");
            return false;
        }

        item.PossessionCount -= amount;
        Debug.Log($"[Inventory] {itemId} -{amount}�i�c�� {item.PossessionCount}�j");
        OnInventoryChanged?.Invoke();
        return true;
    }

    /// <summary>
    /// ���������擾�i���݂��Ȃ��ꍇ��0�j
    /// </summary>
    public int GetCount(string itemId)
    {
        var item = m_itemStatuses.Find(i => i.ItemId == itemId);
        return item?.PossessionCount ?? 0;
    }

    /// <summary>
    /// �S�����f�[�^���擾�i�Z�[�u�p�j
    /// </summary>
    public IReadOnlyList<PlayerItemStatus> GetAllItems() => m_itemStatuses.AsReadOnly();

    /// <summary>
    /// �����A�C�e�����N���A�i�f�o�b�O�p�j
    /// </summary>
    [ContextMenu("Clear Inventory")]
    public void ClearInventory()
    {
        m_itemStatuses.Clear();
        OnInventoryChanged?.Invoke();
        Debug.Log("[Inventory] �S�A�C�e�����N���A���܂���");
    }
}
