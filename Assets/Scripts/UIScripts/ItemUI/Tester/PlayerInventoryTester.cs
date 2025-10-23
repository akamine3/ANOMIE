using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryTester : MonoBehaviour
{
    [Header("参照するデータ")]
    [SerializeField] PlayerInventory m_playerInventory;     // 実際のインベントリ管理クラス
    [SerializeField] ItemDataBase m_itemDatabase;           // マスターデータ

    [Header("テスト入力")]
    [SerializeField] string m_testItemId;                   // 追加したいアイテムID
    [SerializeField, Range(1, 99)] int m_testAmount = 1;                  // 増やす数

    [ContextMenu("Add Test Item")]
    public void AddTestItem()
    {
        m_playerInventory.AddItem(m_testItemId, m_testAmount);

    }
}
