using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    [Header("ScrollView管理")]
    [SerializeField] private ScrollViewSwitcher m_switcher;
    [SerializeField] private GameObject m_itemSlotPrefab;

    [Header("データ参照")]
    [SerializeField] private ItemDataBase m_itemDatabase;
    [SerializeField] private PlayerInventory m_playerInventory;

    private Transform m_currentContentParent;
    private Dictionary<string, ItemSlotUI> m_spawnedSlots = new();

    private void Start()
    {
        // イベント登録
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged += OnInventoryChanged;

        // 初期表示
        OnInventoryChanged();
    }

    private void OnDestroy()
    {
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged -= OnInventoryChanged;
    }

    /// <summary>
    /// インベントリ変更時のUI更新
    /// </summary>
    private void OnInventoryChanged()
    {
        // 今回は「通常アイテム」タブのみ表示（必要に応じて切り替え可）
        Debug.Log("[UI] OnInventoryChanged() 呼ばれた");
        RefreshUI(ItemDataBase.ItemData.ItemType.Quest);
    }

    /// <summary>
    /// UIを更新（差分追加方式＋空チェック）
    /// </summary>
    public void RefreshUI(ItemDataBase.ItemData.ItemType type)
    {
        m_switcher.Show(type);
        m_currentContentParent = m_switcher.GetCurrentContent();

        // 現在の所持アイテム一覧を取得
        var ownedItems = m_playerInventory.GetAllItems();
        if (ownedItems == null || ownedItems.Count == 0)
        {
            Debug.Log("[UI] アイテムを所持していません");
            // 既存UIを削除しておく（空表示）
            foreach (Transform child in m_currentContentParent)
                Destroy(child.gameObject);
            m_spawnedSlots.Clear();
            return;
        }

        // 所持アイテムに基づいてUIを更新
        foreach (var owned in ownedItems)
        {
            // マスターから該当アイテムを検索
            var data = m_itemDatabase.ItemList.Find(i => i.ItemId == owned.ItemId && i.Type == type);
            if (data == null) continue; // 他カテゴリはスキップ

            // 既に表示済みか？
            if (m_spawnedSlots.ContainsKey(owned.ItemId))
            {
                m_spawnedSlots[owned.ItemId].UpdateUI();
                continue;
            }

            // 新規アイテムの場合 → スロット生成
            var slotObj = Instantiate(m_itemSlotPrefab, m_currentContentParent);
            slotObj.name = owned.ItemId;
            var slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetItemId(owned.ItemId);

            m_spawnedSlots.Add(owned.ItemId, slotUI);
        }
    }
}
