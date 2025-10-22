using UnityEngine;

public class ScrollViewSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject m_scrollQuest;
    [SerializeField] private GameObject m_scrollConsumable;
    [SerializeField] private GameObject m_scrollPassive;

    private GameObject m_currentActive;

    void Start()
    {
        // �����\�����N�G�X�g�ɐݒ�
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
        // ���ׂĔ�\��
        m_scrollQuest.SetActive(false);
        m_scrollConsumable.SetActive(false);
        m_scrollPassive.SetActive(false);

        // �Ώۂ̂ݕ\��
        target.SetActive(true);
        m_currentActive = target;
    }
}
