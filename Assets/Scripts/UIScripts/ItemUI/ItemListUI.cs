using UnityEngine;

public class ItemListUI : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] private PlayerInventory m_playerInventory; // 所持データ
    [SerializeField] private ItemDataBase m_itemDatabase;       // アイテムマスター
    [SerializeField] private ItemSlotUI m_slotPrefab;           // スロットプレハブ
    [SerializeField] private Transform m_slotParent;            // 配置先（GridLayoutGroup推奨）

    private void Start()
    {
        GenerateItemSlots();
    }

    /// <summary>
    /// アイテムスロットを一覧生成
    /// </summary>
    private void GenerateItemSlots()
    {
        // 既存スロット削除（再生成対策）
        foreach (Transform child in m_slotParent)
        {
            Destroy(child.gameObject);
        }

        // マスターに登録された全アイテムをUI化
        foreach (var data in m_itemDatabase.ItemList)
        {
            // プレハブを生成
            ItemSlotUI slot = Instantiate(m_slotPrefab, m_slotParent);

            // データベースとインベントリを参照に設定
            slot.GetComponent<ItemSlotUI>().SetItemId(data.ItemId);
        }
    }
}
