using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemDataBase;

// Save target
[System.Serializable]
public class PlayerItemStatus
{
    [SerializeField] private string m_itemId;       // マスターデータと一致するID
    [SerializeField] private int m_possessionCount; // 所持数
    [SerializeField] private bool m_isUsed;         // 使用済みフラグ

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