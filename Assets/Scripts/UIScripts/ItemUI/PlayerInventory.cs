using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public event Action OnInventoryChanged;

    [Header("所有アイテム一覧")]
    [SerializeField] private List<PlayerItemStatus> ItemStatuses = new();

    private void Awake()
    {
        // シングルトン化
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// アイテムをリストに加える
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

        Debug.Log($"{itemId} が {amount} 個増えた！（現在：{item?.PossessionCount ?? amount}）");

        // 変更
        if (OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }

    /// <summary>
    /// アイテム使用時
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="amount"></param>
    public void UseItem(string itemId, int amount = 1)
    {
        var item = ItemStatuses.Find(i => i.ItemId == itemId);
        if (item == null)
        {
            Debug.LogWarning($"[{itemId}] は所持していません。");
            return;
        }

        if (item.PossessionCount < amount)
        {
            Debug.LogWarning($"[{itemId}] の所持数が足りません。");
            return;
        }

        item.PossessionCount -= amount;
        Debug.Log($"[{itemId}] を {amount} 個使用。残り: {item.PossessionCount}");

        if (OnInventoryChanged != null) OnInventoryChanged.Invoke();
    }

    /// <summary>
    /// 所持数取得メソッド
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public int GetCount(string itemId)
    {
        var item = ItemStatuses.Find(i => i.ItemId == itemId);
        if (item != null)
            return item.PossessionCount; // アイテムが見つかったら所持数を返す
        else
            return 0;
    }
}
