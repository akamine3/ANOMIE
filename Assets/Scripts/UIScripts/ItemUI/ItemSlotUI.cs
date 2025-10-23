using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image m_iconImage;
    [SerializeField] private TextMeshProUGUI m_numText;
    [SerializeField] private ItemDataBase m_database; // ← Inspectorで設定

    private string m_itemId;
    private ItemUIManager m_uiManager;
    private PlayerInventory m_inventory;

    private void Awake()
    {
        m_uiManager = FindObjectOfType<ItemUIManager>();
        m_inventory = PlayerInventory.Instance;
    }

    public void SetItemId(string itemId)
    {
        m_itemId = itemId;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (m_database == null)
        {
            Debug.LogError("[ItemSlotUI] ItemDataBaseが未設定です。Prefabまたはシーンで設定してください。");
            return;
        }

        var data = m_database.ItemList.Find(i => i.ItemId == m_itemId);
        if (data != null)
        {
            m_iconImage.sprite = data.Icon;
            m_iconImage.preserveAspect = true;
        }

        if (m_inventory != null)
            m_numText.text = m_inventory.GetCount(m_itemId).ToString();
    }
}
