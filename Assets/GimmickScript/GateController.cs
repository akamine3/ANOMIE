using UnityEngine;
using UnityEngine.Tilemaps;

public class GateController : MonoBehaviour
{
    [SerializeField] private string requiredItemId;
    [SerializeField] private Vector3Int[] gateTilesToClear; // ����Tile�̍��W

    private Tilemap tilemap;
    private TilemapCollider2D tilemapCollider;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = GetComponent<TilemapCollider2D>();

        if (tilemap == null || tilemapCollider == null)
        {
            Debug.LogError("TilemapCollider2D ��������܂���B");
            return;
        }

        Debug.Log($"GateController �N��: �K�v��ID = '{requiredItemId}'");
        Debug.Log($"HasItem('{requiredItemId}') = {InventoryManager.Instance.HasItem(requiredItemId)}");


        if (string.IsNullOrEmpty(requiredItemId))
        {
            Debug.LogWarning("requiredItemId ���ݒ肳��Ă��܂���I");
            return;
        }

        // �ŏ����玝���Ă���ΊJ����
        if (InventoryManager.Instance.HasItem(requiredItemId))
        {
            OpenGate();
        }
        else
        {
            // �A�C�e���擾���ɒʒm���󂯎��
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
            tilemap.SetTile(pos, null); // Tile������
        }

        Debug.Log("�����J�����I");
    }

    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnItemAdded -= OnItemAdded;
    }
}