using System.Collections;
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

    [Header("NoItems 表示テキスト")]
    [SerializeField] private GameObject m_noItemQuest;
    [SerializeField] private GameObject m_noItemConsumable;
    [SerializeField] private GameObject m_noItemPassive;

    [Header("アイテム詳細パネル")]
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
            Debug.LogError("[ItemUIManager] Item Slot Prefab が実行時に Missing です。Prefab 参照が壊れています。");
        else
            Debug.Log($"[ItemUIManager] Prefab OK: {m_itemSlotPrefab.name}");

        // イベント登録
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged += OnInventoryChanged;

        // アイテム詳細パネル設定
        if (m_detailUI != null)
            m_detailUI.Initialize(m_itemDatabase);

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
        int count = m_playerInventory?.GetEventListenerCount() ?? 0;
        Debug.Log($"[UI] OnInventoryChangedが呼ばれた (登録回数: {count})");

        // 現在の表示タブのカテゴリのみ更新
        var currentType = m_switcher.GetCurrentType();
        RefreshUI(currentType);
    }


    private IEnumerator RefreshAfterClear()
    {
        yield return null; // 1フレーム待つ
        foreach (ItemDataBase.ItemData.ItemType type in System.Enum.GetValues(typeof(ItemDataBase.ItemData.ItemType)))
        {
            RefreshUI(type);
        }
    }

    /// <summary>
    /// UIを更新
    /// </summary>
    public void RefreshUI(ItemDataBase.ItemData.ItemType type)
    {
        StartCoroutine(RefreshUICoroutine(type));
    }

    private IEnumerator RefreshUICoroutine(ItemDataBase.ItemData.ItemType type)
    {
        // タブを切り替え
        m_switcher.Show(type);
        yield return null; // 1フレーム待機

        m_currentContentParent = m_switcher.GetCurrentContent();
        if (m_currentContentParent == null)
        {
            Debug.LogError($"[UI] Contentが見つかりません: {type}");
            yield break;
        }

        // 全NoItemsを一旦非表示
        if (m_noItemQuest) m_noItemQuest.SetActive(false);
        if (m_noItemConsumable) m_noItemConsumable.SetActive(false);
        if (m_noItemPassive) m_noItemPassive.SetActive(false);

        // 所持アイテム一覧
        var ownedItems = m_playerInventory?.GetAllItems();
        if (ownedItems == null) yield break;

        // スロット削除
        foreach (Transform child in m_currentContentParent)
            Destroy(child.gameObject);
        m_spawnedSlots.Clear();

        // 対象タイプの抽出
        var itemsOfType = ownedItems
            .Where(i => i != null &&
                        m_itemDatabase.ItemList.Any(d => d.ItemId == i.ItemId && d.Type == type))
            .ToList();

        Debug.Log($"[UI] {type} タイプの所持数: {itemsOfType.Count}");

        bool hasAny = itemsOfType.Count > 0;

        // NoItems表示制御（再有効化）
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
            Debug.Log($"[UI] {type} に属するアイテムなし → NoItems表示");
            yield break;
        }

        // スロット生成
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

        Debug.Log($"[UI] {type} のスロット生成完了: {m_spawnedSlots.Count}個");
    }

    /// <summary>
    /// UIボタンから呼び出す: タブ切り替え
    /// </summary>
    public void ChangeTab(ItemDataBase.ItemData.ItemType type)
    {
        Debug.Log($"[ItemUIManager] タブ切り替え: {type}");
        RefreshUI(type);
    }


    public void OnItemSelected(string itemId)
    {
        Debug.Log($"[ItemUIManager] 選択アイテム: {itemId}");
        if (m_detailUI != null)
            m_detailUI.ShowItem(itemId);
    }
}
