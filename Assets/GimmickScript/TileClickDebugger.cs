using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClickDebugger : MonoBehaviour
{
    [SerializeField] private Tilemap targetTilemap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = targetTilemap.WorldToCell(mouseWorldPos);
            Debug.Log($"クリックしたTileの座標: {cellPos}");
        }
    }
}