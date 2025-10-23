using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private Transform contentParent;     // ScrollViewのContent
    [SerializeField] private GameObject itemSlotPrefab;   // ItemSlotUIを持つプレハブ
    [SerializeField] private PlayerInventory playerInventory; // 所持情報

    private List<GameObject> currentSlots = new();

    void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        // 既存スロット削除
        foreach (var slot in currentSlots) Destroy(slot);
        currentSlots.Clear();

        // 所持アイテムに応じて生成
        foreach (var item in playerInventory.GetAllItems())
        {
            GameObject obj = Instantiate(itemSlotPrefab, contentParent);
            var ui = obj.GetComponent<ItemSlotUI>();
            ui.SetItemId(item.ItemId);
            currentSlots.Add(obj);
        }
    }
}
