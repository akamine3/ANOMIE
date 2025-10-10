using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] private Image m_iconImage;          // アイコン画像
    [SerializeField] private TextMeshProUGUI m_numText;  // 所持数テキスト
    [SerializeField] private ItemDataBase m_itemDatabase;
    [SerializeField] private PlayerInventory m_playerInventory;
    [SerializeField] private string m_itemId; // 表示したいアイテムID

    private void OnEnable()
    {
        // イベント読み込み
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged += UpdateUI;

        // 初回表示も整える
        UpdateUI();
    }

    private void OnDisable()
    {
        // イベント読み込み解除（OFFになったら）
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    // UIを更新
    public void UpdateUI()
    {
        // マスターからアイテム情報を取得
        var data = m_itemDatabase.ItemList.Find(d => d.ItemId == m_itemId);

        if (data != null)
        {
            m_iconImage.sprite = data.Icon; // アイコン設定
        }

        // 現在の所持数を取得して表示
        int count = m_playerInventory.GetCount(m_itemId);
        m_numText.text = count.ToString();
    }

    public void OnClickItemIcon()
    {
        Debug.Log("[Button] アイテムが選択されました");
    }
}
