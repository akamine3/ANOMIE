using UnityEngine;
using UnityEngine.Tilemaps;

public class GateController : MonoBehaviour
{
    [SerializeField] private int requiredItemId;
    private TilemapCollider2D tilemapCollider;

    void Start()
    {
        tilemapCollider = GetComponent<TilemapCollider2D>();

        if (tilemapCollider == null)
        {
            Debug.LogError("TilemapCollider2D が見つかりません。");
            return;
        }

        // 最初から持っていれば開ける
        if (InventoryManager.Instance.HasItem(requiredItemId))
        {
            OpenGate();
        }
        else
        {
            // アイテム取得時に通知を受け取る
            InventoryManager.Instance.OnItemAdded += OnItemAdded;
        }
    }

    private void OnItemAdded(int itemId)
    {
        if (itemId == requiredItemId)
        {
            OpenGate();
        }
    }

    private void OpenGate()
    {
        tilemapCollider.enabled = false;
        Debug.Log("道が開いた！");
    }

    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnItemAdded -= OnItemAdded;
    }
}