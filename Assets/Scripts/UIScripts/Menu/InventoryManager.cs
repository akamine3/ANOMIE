using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    // �������Ă���A�C�e����ID��ێ�����
    private HashSet<int> ownedItemIds = new HashSet<int>();

    public event Action<int> OnItemAdded; // �A�C�e���ǉ��C�x���g

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // �A�C�e�����C���x���g���ɒǉ����郁�\�b�h�B
    public void AddItem(ItemData item)
    {
        // �A�C�e����ID���n�b�V���Z�b�g�ɒǉ�
        if (ownedItemIds.Add(item.ItemId))
        {
            Debug.Log($"�A�C�e���ǉ�: {item.ItemName} (ID: {item.ItemId})");
            OnItemAdded?.Invoke(item.ItemId); // �C�x���g���N��
        }
        else
        {
            Debug.Log($"�A�C�e���͊��ɏ������Ă��܂�: {item.ItemName} (ID: {item.ItemId})");
        }
        //ownedItemIds.Add(item.ItemId);
    }
    // �A�C�e��ID���������Ă��邩�m�F���郁�\�b�h�B
    public bool HasItem(int itemId)
    {
        return ownedItemIds.Contains(itemId);
    }
}
