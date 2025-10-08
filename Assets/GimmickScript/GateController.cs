using UnityEngine;
using UnityEngine.Tilemaps;

public class GateController : MonoBehaviour
{
    [SerializeField] private string requiredItemId;
    private TilemapCollider2D tilemapCollider;

    void Start()
    {
        tilemapCollider = GetComponent<TilemapCollider2D>();

        if (tilemapCollider == null)
        {
            Debug.LogError("TilemapCollider2D が見つかりません。");
            return;
        }

        Debug.Log($"GateController 起動: 必要なID = '{requiredItemId}'");
        Debug.Log($"HasItem('{requiredItemId}') = {InventoryManager.Instance.HasItem(requiredItemId)}");


        if (string.IsNullOrEmpty(requiredItemId))
        {
            Debug.LogWarning("requiredItemId が設定されていません！");
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

    private void OnItemAdded(string itemId)
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