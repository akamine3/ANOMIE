using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailUI : MonoBehaviour
{
    [Header("�Q��UI")]
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_nameText;
    [SerializeField] private TextMeshProUGUI m_numCount;
    [SerializeField] private TextMeshProUGUI m_numText;
    [SerializeField] private TextMeshProUGUI m_descriptionText;
    [SerializeField] private GameObject m_noItemText;
    [SerializeField] private ItemDataBase m_database;
    [SerializeField] private PlayerInventory m_inventory;


    private void Awake()
    {
        //m_inventory = PlayerInventory.Instance;

        // �����Q�Ƃ������Ă���Ƃ��̕�U
        if (m_inventory == null)
            m_inventory = PlayerInventory.Instance;

        if (m_database == null)
            m_database = Resources.Load<ItemDataBase>("ItemDatabase"); // �p�X�͕K�v�ɉ����ďC��
    }

    public void Initialize(ItemDataBase database)
    {
        m_database = database;
        Clear();
    }

    public void ShowItem(string itemId)
    {
        if (m_database == null || m_inventory == null)
        {
            Debug.LogWarning("[ItemDetailUI] Database or Inventory is missing.");
            return;
        }

        var data = m_database.ItemList.Find(i => i.ItemId == itemId);
        if (data == null)
        {
            Debug.LogWarning($"[ItemDetailUI] Item not found: {itemId}");
            Clear();
            return;
        }

        if (m_noItemText) m_noItemText.SetActive(false);

        m_nameText.text = data.ItemName;
        m_descriptionText.text = data.Description;

        // �������e�L�X�g��\�����X�V
        if (m_numText)
        {
            m_numText.gameObject.SetActive(true); // �\��ON
            int count = m_inventory.GetCount(itemId);
            m_numText.text = count.ToString();
            Debug.Log($"[ItemDetailUI] {itemId} ������={count}");
        }

        if (m_icon)
        {
            m_icon.sprite = data.Icon;
            m_icon.preserveAspect = true;
            m_icon.enabled = (data.Icon != null);
        }
    }

    public void Clear()
    {
        if (m_icon) m_icon.enabled = false;
        if (m_nameText) m_nameText.text = "";
        if (m_noItemText) m_numText.gameObject.SetActive(false);
        if (m_numCount) m_numCount.text = "";
        if (m_descriptionText) m_descriptionText.text = "";
        if (m_noItemText) m_noItemText.SetActive(true);
    }
}
