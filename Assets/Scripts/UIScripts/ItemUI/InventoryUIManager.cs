using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private Transform contentParent;     // ScrollView��Content
    [SerializeField] private GameObject itemSlotPrefab;   // ItemSlotUI�����v���n�u
    [SerializeField] private PlayerInventory playerInventory; // �������

    private List<GameObject> currentSlots = new();

    void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        // �����X���b�g�폜
        foreach (var slot in currentSlots) Destroy(slot);
        currentSlots.Clear();

        // �����A�C�e���ɉ����Đ���
        foreach (var item in playerInventory.GetAllItems())
        {
            GameObject obj = Instantiate(itemSlotPrefab, contentParent);
            var ui = obj.GetComponent<ItemSlotUI>();
            ui.SetItemId(item.ItemId);
            currentSlots.Add(obj);
        }
    }
}
