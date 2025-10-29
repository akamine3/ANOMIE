using UnityEngine;

public class ScrollViewSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject m_scrollQuest;
    [SerializeField] private GameObject m_scrollConsumable;
    [SerializeField] private GameObject m_scrollPassive;



    private GameObject m_currentActive;
    private ItemDataBase.ItemData.ItemType m_currentType;

    public void Show(ItemDataBase.ItemData.ItemType type)
    {
        // ScrollView の表示切替
        m_scrollQuest.SetActive(type == ItemDataBase.ItemData.ItemType.Quest);
        m_scrollConsumable.SetActive(type == ItemDataBase.ItemData.ItemType.Active);
        m_scrollPassive.SetActive(type == ItemDataBase.ItemData.ItemType.Passive);

        // 現在タブ記録
        m_currentType = type;
        switch (type)
        {
            case ItemDataBase.ItemData.ItemType.Quest: m_currentActive = m_scrollQuest; break;
            case ItemDataBase.ItemData.ItemType.Active: m_currentActive = m_scrollConsumable; break;
            case ItemDataBase.ItemData.ItemType.Passive: m_currentActive = m_scrollPassive; break;
        }
    }

    public Transform GetCurrentContent()
    {
        var content = m_currentActive?.transform.Find("Viewport/Content");
        if (content == null)
            Debug.LogError("[ScrollViewSwitcher] Viewport/Content が見つかりません");
        return content;
    }

    public ItemDataBase.ItemData.ItemType GetCurrentType() => m_currentType;

}
