using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject useKeyButton; // UI�{�^��
    [SerializeField] private string requiredItemId;
    [SerializeField] private GateController gateController;

    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            useKeyButton.SetActive(true); // �{�^���\��
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            useKeyButton.SetActive(false); // �{�^����\��
        }
    }

    public void TryUseKey()
    {
        if (playerInRange && InventoryManager.Instance.HasItem(requiredItemId))
        {
            InventoryManager.Instance.ConsumeItem(requiredItemId); // ��������폜
            gateController.OpenGate(); // �����J��
            useKeyButton.SetActive(false); // �{�^��������
        }
    }
}