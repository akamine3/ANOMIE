using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemDataBase;

// Save target
[System.Serializable]
public class PlayerItemStatus
{
    [SerializeField] private string m_itemId;       // �}�X�^�[�f�[�^�ƈ�v����ID
    [SerializeField] private int m_possessionCount; // ������
    [SerializeField] private bool m_isUsed;         // �g�p�ς݃t���O

    public string ItemId => m_itemId;
    public int PossessionCount
    {
        get => m_possessionCount;
        set => m_possessionCount = value;
    }

    public bool IsUsed
    {
        get => m_isUsed;
        set => m_isUsed = value;
    }

    public PlayerItemStatus(string itemId, int possessionCount)
    {
        m_itemId = itemId;
        m_possessionCount = possessionCount;
        m_isUsed = false;
    }
}