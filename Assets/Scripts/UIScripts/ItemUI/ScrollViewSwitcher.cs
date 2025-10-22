using UnityEngine;

public class ScrollViewSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject m_scrollQuest;
    [SerializeField] private GameObject m_scrollConsumable;
    [SerializeField] private GameObject m_scrollPassive;

    private GameObject m_currentActive;

    void Start()
    {
        // 初期表示をクエストに設定
        ShowQuest();
    }

    public void ShowQuest()
    {
        SetActiveScroll(m_scrollQuest);
    }

    public void ShowConsumable()
    {
        SetActiveScroll(m_scrollConsumable);
    }

    public void ShowPassive()
    {
        SetActiveScroll(m_scrollPassive);
    }

    private void SetActiveScroll(GameObject target)
    {
        // すべて非表示
        m_scrollQuest.SetActive(false);
        m_scrollConsumable.SetActive(false);
        m_scrollPassive.SetActive(false);

        // 対象のみ表示
        target.SetActive(true);
        m_currentActive = target;
    }
}
