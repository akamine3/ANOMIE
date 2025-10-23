using UnityEngine;
using UnityEngine.UI;

public class ItemTabButton : MonoBehaviour
{
    [SerializeField] private ItemDataBase.ItemData.ItemType m_tabType;
    [SerializeField] private ItemUIManager m_itemUIManager;
    [SerializeField] private Button m_button;

    private void Awake()
    {
        if (m_button == null)
            m_button = GetComponent<Button>();

        m_button.onClick.AddListener(OnTabClicked);
    }

    private void OnDestroy()
    {
        if (m_button != null)
            m_button.onClick.RemoveListener(OnTabClicked);
    }

    private void OnTabClicked()
    {
        Debug.Log($"[ItemTabButton] {m_tabType} タブクリック");
        m_itemUIManager.RefreshUI(m_tabType);
    }
}
