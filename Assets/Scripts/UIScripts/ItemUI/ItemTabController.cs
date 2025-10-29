using UnityEngine;
using UnityEngine.UI;

public class ItemTabController : MonoBehaviour
{
    [Header("このボタンが担当するアイテムカテゴリ")]
    [SerializeField] private ItemDataBase.ItemData.ItemType m_type;

    [Header("このタブのボタン (自動設定可)")]
    [SerializeField] private Button m_button;

    private ItemUIManager m_uiManager;

    private void Awake()
    {
        // ボタンが未設定なら自動取得
        if (m_button == null)
            m_button = GetComponent<Button>();

        // シーン内の ItemUIManager を検索
        m_uiManager = FindObjectOfType<ItemUIManager>();

        if (m_uiManager == null)
        {
            Debug.LogError("[ItemTabController] ItemUIManager が見つかりません。");
            return;
        }

        // ボタンクリックイベント登録
        m_button.onClick.AddListener(OnTabClicked);
    }

    private void OnDestroy()
    {
        if (m_button != null)
            m_button.onClick.RemoveListener(OnTabClicked);
    }

    private void OnTabClicked()
    {
        Debug.Log($"[ItemTabController] {m_type} タブクリック");
        m_uiManager.ChangeTab(m_type);
    }
}
