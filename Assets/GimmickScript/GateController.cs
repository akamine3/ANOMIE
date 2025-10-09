using UnityEngine;
using UnityEngine.Tilemaps;

public class GateController : MonoBehaviour
{
    [SerializeField] private string requiredItemId;
    [SerializeField] private Vector3Int[] gateTilesToClear; // 消すTileの座標

    private Tilemap tilemap;
    private TilemapCollider2D tilemapCollider;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = GetComponent<TilemapCollider2D>();

        if (tilemap == null || tilemapCollider == null)
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

        foreach (var pos in gateTilesToClear)
        {
            tilemap.SetTile(pos, null); // Tileを消す
        }

        Debug.Log("道が開いた！");
    }

    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnItemAdded -= OnItemAdded;
    }
}