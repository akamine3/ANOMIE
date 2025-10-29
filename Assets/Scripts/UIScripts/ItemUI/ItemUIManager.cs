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
        // このタブを表示し、Contentを取得
        m_switcher.Show(type);
        m_currentContentParent = m_switcher.GetCurrentContent();
        if (m_currentContentParent == null)
        {
            Debug.LogError("[UI] Contentが見つかりません");
            return;
        }

        // 所持アイテムをカテゴリ＆所持数>0で厳密に抽出
        var ownedItems = m_playerInventory?.GetAllItems();
        var filtered = (ownedItems == null)
            ? new List<PlayerItemStatus>()
            : ownedItems.Where(i =>
                  i != null && i.PossessionCount > 0 &&
                  m_itemDatabase.ItemList.Any(d => d.ItemId == i.ItemId && d.Type == type)
              ).ToList();

        // まず既存スロットを全削除
        foreach (Transform child in m_currentContentParent)
            Destroy(child.gameObject);
        m_spawnedSlots.Clear();

        // NoItemsテキストは毎回「全てOFF」→必要なら対象のみON
        if (m_noItemQuest) m_noItemQuest.SetActive(false);
        if (m_noItemConsumable) m_noItemConsumable.SetActive(false);
        if (m_noItemPassive) m_noItemPassive.SetActive(false);

        // 空なら、該当タブのNoItemsだけONにして終了
        if (filtered.Count == 0)
        {
            switch (type)
            {
                case ItemDataBase.ItemData.ItemType.Quest:
                    if (m_playerInventory.ItemStatuses.Count(
                        i => m_itemDatabase.ItemList.Any(d => d.Type == ItemDataBase.ItemData.ItemType.Quest)) < 0) 
                        m_noItemQuest.SetActive(true);
                    break;
                case ItemDataBase.ItemData.ItemType.Active:
                    if (m_playerInventory.ItemStatuses.Count(
                        i => m_itemDatabase.ItemList.Any(d => d.Type == ItemDataBase.ItemData.ItemType.Active)) < 0)
                        m_noItemConsumable.SetActive(true);
                    break;
                case ItemDataBase.ItemData.ItemType.Passive:
                    if (m_playerInventory.ItemStatuses.Count(
                        i => m_itemDatabase.ItemList.Any(d => d.Type == ItemDataBase.ItemData.ItemType.Passive)) < 0)
                        m_noItemPassive.SetActive(true); 
                    break;
            }

            Debug.Log($"[UI] NoItems表示: type={type}, filtered=0");
            return;
        }

        // スロット生成（filteredだけ）
        foreach (var owned in filtered)
        {
            var slotObj = Instantiate(m_itemSlotPrefab, m_currentContentParent);
            slotObj.name = owned.ItemId;
            var slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetItemId(owned.ItemId);
            m_spawnedSlots[owned.ItemId] = slotUI;
        }

        // 生成できたので該当NoItemsは必ずOFF（保険）
        switch (type)
        {
            case ItemDataBase.ItemData.ItemType.Quest:
                if (m_noItemQuest) m_noItemQuest.SetActive(false);
                break;
            case ItemDataBase.ItemData.ItemType.Active:
                if (m_noItemConsumable) m_noItemConsumable.SetActive(false);
                break;
            case ItemDataBase.ItemData.ItemType.Passive:
                if (m_noItemPassive) m_noItemPassive.SetActive(false);
                break;
        }

        Debug.Log($"[UI] 生成完了: type={type}, filtered={filtered.Count}, slots={m_spawnedSlots.Count}");
    }


    /// <summary>
    /// UIボタンから呼び出す: タブ切り替え
    /// </summary>
    public void ChangeTab(ItemDataBase.ItemData.ItemType type)
    {
        Debug.Log($"[ItemUIManager] タブ切り替え: {type}");
        RefreshUI(type);
    }

}
