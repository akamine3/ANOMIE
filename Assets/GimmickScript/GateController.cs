using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GateController : MonoBehaviour
{
    [System.Serializable]
    public class GateData
    {
        public string requiredItemId;
        public Vector3Int[] gateTilesToClear;
    }

    [SerializeField] private List<GateData> gates = new List<GateData>();

    private Tilemap tilemap;
    private TilemapCollider2D tilemapCollider;
    private HashSet<string> openedGates = new HashSet<string>();

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = GetComponent<TilemapCollider2D>();

        if (tilemap == null || tilemapCollider == null)
        {
            Debug.LogError("Tilemap または TilemapCollider2D が見つかりません。");
            return;
        }

        InventoryManager.Instance.OnItemAdded += OnItemAdded;

        // すでに持っているアイテムで開けられるゲートをチェック
        foreach (var gate in gates)
        {
            if (InventoryManager.Instance.HasItem(gate.requiredItemId))
            {
                OpenGate(gate);
            }
        }
    }

    private void OnItemAdded(string itemId)
    {
        foreach (var gate in gates)
        {
            if (gate.requiredItemId == itemId && !openedGates.Contains(itemId))
            {
                OpenGate(gate);
            }
        }
    }

    public void OpenGate(GateData gate)
    {
        foreach (var pos in gate.gateTilesToClear)
        {
            tilemap.SetTile(pos, null);
        }

        tilemapCollider.enabled = false;
        openedGates.Add(gate.requiredItemId);

        Debug.Log($"道が開いた！（ID: {gate.requiredItemId}）");
    }
    /*public List<GateData> GetGates()
    {
        return gates;
    }*/
    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnItemAdded -= OnItemAdded;
    }
}