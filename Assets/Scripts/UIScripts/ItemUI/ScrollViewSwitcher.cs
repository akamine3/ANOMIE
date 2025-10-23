using UnityEngine;

public class ScrollViewSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject m_scrollQuest;
    [SerializeField] private GameObject m_scrollConsumable;
    [SerializeField] private GameObject m_scrollPassive;
    private ItemDataBase.ItemData.ItemType m_currentType;

    private GameObject m_currentActive;

    public void Show(ItemDataBase.ItemData.ItemType type)
    {
        m_currentType = type;

        m_scrollQuest.SetActive(type == ItemDataBase.ItemData.ItemType.Quest);
        m_scrollConsumable.SetActive(type == ItemDataBase.ItemData.ItemType.Active);
        m_scrollPassive.SetActive(type == ItemDataBase.ItemData.ItemType.Passive);

        switch (type)
        {
            case ItemDataBase.ItemData.ItemType.Quest: m_currentActive = m_scrollQuest; break;
            case ItemDataBase.ItemData.ItemType.Active: m_currentActive = m_scrollConsumable; break;
            case ItemDataBase.ItemData.ItemType.Passive: m_currentActive = m_scrollPassive; break;
        }
    }

    public ItemDataBase.ItemData.ItemType GetCurrentType()
    {
        return m_currentType;
    }

    public Transform GetCurrentContent()
    {
        if (m_currentActive == null)
        {
            Debug.LogError("[ScrollViewSwitcher] 現在アクティブなScrollViewが未設定です。Show()を先に呼んでください。");
            return null;
        }

        var content = m_currentActive.transform.Find("Viewport/Content");
        if (content == null)
        {
            Debug.LogError("[ScrollViewSwitcher] Viewport/Content が見つかりません");
            return null;
        }

        return content;
    }

}
