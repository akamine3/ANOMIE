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
        Debug.Log($"[UI] OnInventoryChanged() 呼ばれた (登録回数: {count})");

        //Debug.Log("[UI] OnInventoryChanged() 呼ばれた");

        foreach (ItemDataBase.ItemData.ItemType type in System.Enum.GetValues(typeof(ItemDataBase.ItemData.ItemType)))
        {
            StartCoroutine(RefreshAfterClear());
        }
        /*        // 現在表示しているタブのタイプを取得
                var currentType = m_switcher.GetCurrentType();

                // 現在のタブに反映
                RefreshUI(currentType);

                // レイアウト強制更新
                Canvas.ForceUpdateCanvases();*/
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
    /// UIを更新（差分追加方式＋空チェック）
    /// </summary>
    public void RefreshUI(ItemDataBase.ItemData.ItemType type)
    {
        // 対象ScrollViewを表示
        m_switcher.Show(type);

        // 現在のContent Transformを取得（生成先）
        m_currentContentParent = m_switcher.GetCurrentContent();
        if (m_currentContentParent == null)
        {
            Debug.LogError("[UI] Content が取得できませんでした。ScrollView の構造を確認してください。");
            return;
        }

        // 所持アイテムを取得
        var ownedItems = m_playerInventory.GetAllItems();
        if (ownedItems == null || ownedItems.Count == 0)
        {
            Debug.Log("[UI] アイテムを所持していません");

            foreach (Transform child in m_currentContentParent)
            {
                Destroy(child.gameObject);
            }
            m_spawnedSlots.Clear();
            return;
        }

        // スロット生成
        foreach (var owned in ownedItems)
        {
            var data = m_itemDatabase.ItemList.Find(i => i.ItemId == owned.ItemId && i.Type == type);
            if (data == null) continue;

            if (m_spawnedSlots.ContainsKey(owned.ItemId))
            {
                m_spawnedSlots[owned.ItemId].UpdateUI();
                continue;
            }

            // ここが重要：生成先を m_currentContentParent に変更
            var slotObj = Instantiate(m_itemSlotPrefab, m_currentContentParent);
            slotObj.name = owned.ItemId;

            var slotUI = slotObj.GetComponent<ItemSlotUI>();
            slotUI.SetItemId(owned.ItemId);

            m_spawnedSlots.Add(owned.ItemId, slotUI);
        }

        // レイアウト更新
        Canvas.ForceUpdateCanvases();
    }

}
