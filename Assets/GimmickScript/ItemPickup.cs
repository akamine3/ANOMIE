using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemDataBase.ItemData itemData;

    private void OnTriggerEnter2D(Collider2D other)
    {

        

        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(itemData);
            Debug.Log($"アイテム取得: {itemData.ItemName}");
            Destroy(gameObject); // アイテムを消す
        }
    }
}