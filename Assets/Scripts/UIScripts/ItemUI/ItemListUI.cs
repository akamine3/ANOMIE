using UnityEngine;

public class ItemListUI : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField] private PlayerInventory m_playerInventory; // �����f�[�^
    [SerializeField] private ItemDataBase m_itemDatabase;       // �A�C�e���}�X�^�[
    [SerializeField] private ItemSlotUI m_slotPrefab;           // �X���b�g�v���n�u
    [SerializeField] private Transform m_slotParent;            // �z�u��iGridLayoutGroup�����j

    private void Start()
    {
        GenerateItemSlots();
    }

    /// <summary>
    /// �A�C�e���X���b�g���ꗗ����
    /// </summary>
    private void GenerateItemSlots()
    {
        // �����X���b�g�폜�i�Đ����΍�j
        foreach (Transform child in m_slotParent)
        {
            Destroy(child.gameObject);
        }

        // �}�X�^�[�ɓo�^���ꂽ�S�A�C�e����UI��
        foreach (var data in m_itemDatabase.ItemList)
        {
            // �v���n�u�𐶐�
            ItemSlotUI slot = Instantiate(m_slotPrefab, m_slotParent);

            // �f�[�^�x�[�X�ƃC���x���g�����Q�Ƃɐݒ�
            slot.GetComponent<ItemSlotUI>().SetItemId(data.ItemId);
        }
    }
}
