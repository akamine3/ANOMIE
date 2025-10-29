using UnityEngine;

public class GateChoiceTrigger : MonoBehaviour
{
    [SerializeField] private GameObject choicePanel; // �I�����{�^�����܂Ƃ߂�UI
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            choicePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            choicePanel.SetActive(false);
        }
    }
}