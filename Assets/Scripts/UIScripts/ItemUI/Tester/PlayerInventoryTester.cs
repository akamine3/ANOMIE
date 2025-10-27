using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryTester : MonoBehaviour
{
    [Header("�Q�Ƃ���f�[�^")]
    [SerializeField] PlayerInventory m_playerInventory;     // ���ۂ̃C���x���g���Ǘ��N���X
    [SerializeField] ItemDataBase m_itemDatabase;           // �}�X�^�[�f�[�^

    [Header("�e�X�g����")]
    [SerializeField] string m_testItemId;                   // �ǉ��������A�C�e��ID
    [SerializeField, Range(1, 99)] int m_testAmount = 1;                  // ���₷��

    [ContextMenu("Add Test Item")]
    public void AddTestItem()
    {
        m_playerInventory.AddItem(m_testItemId, m_testAmount);

    }
}
