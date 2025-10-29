using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    [Header("UI参照")]
    [SerializeField] private Image m_itemIcon;
    [SerializeField] private TextMeshProUGUI m_itemNameText;
    [SerializeField] private TextMeshProUGUI m_itemNumText;
    [SerializeField] private TextMeshProUGUI m_itemExplanationText;

    private ItemDataBase m_database;
    private PlayerInventory m_inventory;

    public void Initialize(ItemDataBase database, PlayerInventory inventory)
    {
        m_database = database;
        m_inventory = inventory;
        Clear();
    }

    /// <summary>
    /// 選択中アイテムの詳細を表示
    /// </summary>
    public void ShowItemDetail(string itemId)
    {
        if (m_database == null || m_inventory == null) return;

        var data = m_database.ItemList.Find(i => i.ItemId == itemId);
        if (data == null)
        {
            Clear();
            return;
        }

        m_itemIcon.sprite = data.Icon;
        m_itemIcon.preserveAspect = true;
        m_itemNameText.text = data.ItemName;
        m_itemExplanationText.text = data.Description;

        int count = m_inventory.GetCount(itemId);
        m_itemNumText.text = count.ToString("000");
    }

    public void Clear()
    {
        if (m_itemNameText) m_itemNameText.text = "";
        if (m_itemExplanationText) m_itemExplanationText.text = "";
        if (m_itemNumText) m_itemNumText.text = "";
        if (m_itemIcon) m_itemIcon.sprite = null;
    }
}
