using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの所持アイテムを管理するクラス。
/// UI操作とは独立し、データのみを扱う。
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    /// <summary>所持アイテム更新イベント</summary>
    public event Action OnInventoryChanged;

    [Header("所有アイテム一覧")]
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
    /// アイテムを追加する（既存なら加算）
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

        Debug.Log($"[Inventory] {itemId} +{amount}（現在 {GetCount(itemId)}）");
        OnInventoryChanged?.Invoke();
    }

    /// <summary>
    /// アイテムを消費する（残量チェックあり）
    /// </summary>
    public bool UseItem(string itemId, int amount = 1)
    {
        var item = m_itemStatuses.Find(i => i.ItemId == itemId);
        if (item == null || item.PossessionCount < amount)
        {
            Debug.LogWarning($"[Inventory] {itemId} 使用失敗（不足）");
            return false;
        }

        item.PossessionCount -= amount;
        Debug.Log($"[Inventory] {itemId} -{amount}（残り {item.PossessionCount}）");
        OnInventoryChanged?.Invoke();
        return true;
    }

    /// <summary>
    /// 所持数を取得（存在しない場合は0）
    /// </summary>
    public int GetCount(string itemId)
    {
        var item = m_itemStatuses.Find(i => i.ItemId == itemId);
        return item?.PossessionCount ?? 0;
    }

    /// <summary>
    /// 全所持データを取得（セーブ用）
    /// </summary>
    public IReadOnlyList<PlayerItemStatus> GetAllItems() => m_itemStatuses.AsReadOnly();

    /// <summary>
    /// 所持アイテムをクリア（デバッグ用）
    /// </summary>
    [ContextMenu("Clear Inventory")]
    public void ClearInventory()
    {
        m_itemStatuses.Clear();
        OnInventoryChanged?.Invoke();
        Debug.Log("[Inventory] 全アイテムをクリアしました");
    }
}
