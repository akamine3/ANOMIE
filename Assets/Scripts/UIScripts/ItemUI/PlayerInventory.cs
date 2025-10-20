using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public event Action OnInventoryChanged;

    [Header("���L�A�C�e���ꗗ")]
    [SerializeField] private List<PlayerItemStatus> ItemStatuses = new();

    private void Awake()
    {
        // �V���O���g����
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// �A�C�e�������X�g�ɉ�����
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="amount"></param>
    public void AddItem(string itemId, int amount)
    {
        var item = ItemStatuses.Find(i => i.ItemId == itemId);

        if (item == null)
        {
            ItemStatuses.Add(new PlayerItemStatus(itemId, amount));
        }
        else
        {
            item.PossessionCount += amount;
        }

        Debug.Log($"{itemId} �� {amount} �������I�i���݁F{item?.PossessionCount ?? amount}�j");

        // �ύX
        if (OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }

    /// <summary>
    /// �A�C�e���g�p��
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="amount"></param>
    public void UseItem(string itemId, int amount = 1)
    {
        var item = ItemStatuses.Find(i => i.ItemId == itemId);
        if (item == null)
        {
            Debug.LogWarning($"[{itemId}] �͏������Ă��܂���B");
            return;
        }

        if (item.PossessionCount < amount)
        {
            Debug.LogWarning($"[{itemId}] �̏�����������܂���B");
            return;
        }

        item.PossessionCount -= amount;
        Debug.Log($"[{itemId}] �� {amount} �g�p�B�c��: {item.PossessionCount}");

        if (OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }

    /// <summary>
    /// �������擾���\�b�h
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public int GetCount(string itemId)
    {
        var item = ItemStatuses.Find(i => i.ItemId == itemId);
        if (item != null)
            return item.PossessionCount; // �A�C�e�������������珊������Ԃ�
        else
            return 0;
    }
}
