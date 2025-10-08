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
            Debug.LogError("TilemapCollider2D ��������܂���B");
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
        Debug.Log("�����J�����I");
    }

    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnItemAdded -= OnItemAdded;
    }
}