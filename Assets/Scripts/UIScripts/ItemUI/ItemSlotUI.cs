using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField] private Image m_iconImage;          // �A�C�R���摜
    [SerializeField] private TextMeshProUGUI m_numText;  // �������e�L�X�g
    [SerializeField] private ItemDataBase m_itemDatabase;
    [SerializeField] private PlayerInventory m_playerInventory;
    [SerializeField] private string m_itemId; // �\���������A�C�e��ID

    private void OnEnable()
    {
        // �C�x���g�ǂݍ���
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged += UpdateUI;

        // ����\����������
        UpdateUI();
    }

    private void OnDisable()
    {
        // �C�x���g�ǂݍ��݉����iOFF�ɂȂ�����j
        if (m_playerInventory != null)
            m_playerInventory.OnInventoryChanged -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    // UI���X�V
    public void UpdateUI()
    {
        // �}�X�^�[����A�C�e�������擾
        var data = m_itemDatabase.ItemList.Find(d => d.ItemId == m_itemId);

        if (data != null)
        {
            m_iconImage.sprite = data.Icon; // �A�C�R���ݒ�
        }

        // ���݂̏��������擾���ĕ\��
        int count = m_playerInventory.GetCount(m_itemId);
        m_numText.text = count.ToString();
    }

    public void OnClickItemIcon()
    {
        Debug.Log("[Button] �A�C�e�����I������܂���");
    }
}
