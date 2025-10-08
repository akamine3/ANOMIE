using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    // 所持しているアイテムのIDを保持する
    private HashSet<string> ownedItemIds = new HashSet<string>();

    public event Action<string> OnItemAdded; // アイテム追加イベント

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // アイテムをインベントリに追加するメソッド。
    public void AddItem(ItemDataBase.ItemData item)
    {
        // アイテムのIDをハッシュセットに追加
        if (ownedItemIds.Add(item.ItemId))
        {
            Debug.Log($"アイテム追加: {item.ItemName} (ID: {item.ItemId})");
            OnItemAdded?.Invoke(item.ItemId); // イベントを起動
        }
        else
        {
            Debug.Log($"アイテムは既に所持しています: {item.ItemName} (ID: {item.ItemId})");
        }
        //ownedItemIds.Add(item.ItemId);
    }
    // アイテムIDを所持しているか確認するメソッド。
    public bool HasItem(string itemId)
    {
        return ownedItemIds.Contains(itemId);
    }
}
