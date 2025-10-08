using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemDataBase.ItemData itemData;

    private void OnTriggerEnter2D(Collider2D other)
    {

        

        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(itemData);
            Debug.Log($"�A�C�e���擾: {itemData.ItemName}");
            Destroy(gameObject); // �A�C�e��������
        }
    }
}