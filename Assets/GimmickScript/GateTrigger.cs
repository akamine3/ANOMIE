using UnityEngine;
using static GateController;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject useKeyButton; // UI�{�^��
    [SerializeField] private string requiredItemId;
    [SerializeField] private GateController gateController;

    [SerializeField] private GateData gateData; // GateTrigger �� GateData ��ݒ�


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

        if (other == null || other.gameObject == null)
            return;

        // ���S�ɃA�N�Z�X
        Debug.Log("Exited: " + other.gameObject.name);

    }

    public void TryUseKey()
    {
        if (playerInRange && InventoryManager.Instance.HasItem(requiredItemId))
        {
            InventoryManager.Instance.ConsumeItem(requiredItemId); // ��������폜
            //gateController.OpenGate(); // �����J��
            gateController.OpenGate(gateData);
            useKeyButton.SetActive(false); // �{�^��������
        }
    }
}