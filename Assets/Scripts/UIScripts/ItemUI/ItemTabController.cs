using UnityEngine;
using UnityEngine.UI;

public class ItemTabController : MonoBehaviour
{
    [Header("���̃{�^�����S������A�C�e���J�e�S��")]
    [SerializeField] private ItemDataBase.ItemData.ItemType m_type;

    [Header("���̃^�u�̃{�^�� (�����ݒ��)")]
    [SerializeField] private Button m_button;

    private ItemUIManager m_uiManager;

    private void Awake()
    {
        // �{�^�������ݒ�Ȃ玩���擾
        if (m_button == null)
            m_button = GetComponent<Button>();

        // �V�[������ ItemUIManager ������
        m_uiManager = FindObjectOfType<ItemUIManager>();

        if (m_uiManager == null)
        {
            Debug.LogError("[ItemTabController] ItemUIManager ��������܂���B");
            return;
        }

        // �{�^���N���b�N�C�x���g�o�^
        m_button.onClick.AddListener(OnTabClicked);
    }

    private void OnDestroy()
    {
        if (m_button != null)
            m_button.onClick.RemoveListener(OnTabClicked);
    }

    private void OnTabClicked()
    {
        Debug.Log($"[ItemTabController] {m_type} �^�u�N���b�N");
        m_uiManager.ChangeTab(m_type);
    }
}
