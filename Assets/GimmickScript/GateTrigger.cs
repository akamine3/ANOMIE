using UnityEngine;
using static GateController;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject useKeyButton; // UIボタン
    [SerializeField] private string requiredItemId;
    [SerializeField] private GateController gateController;

    [SerializeField] private GateData gateData; // GateTrigger に GateData を設定


    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            useKeyButton.SetActive(true); // ボタン表示
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            useKeyButton.SetActive(false); // ボタン非表示
        }

        if (other == null || other.gameObject == null)
            return;

        // 安全にアクセス
        Debug.Log("Exited: " + other.gameObject.name);

    }

    public void TryUseKey()
    {
        if (playerInRange && InventoryManager.Instance.HasItem(requiredItemId))
        {
            InventoryManager.Instance.ConsumeItem(requiredItemId); // 所持から削除
            //gateController.OpenGate(); // 扉を開く
            gateController.OpenGate(gateData);
            useKeyButton.SetActive(false); // ボタンを消す
        }
    }
}