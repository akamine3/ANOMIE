using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public GameObject choicePanel; // �I�����{�^����������UI�p�l��

    void Start()
    {
        choicePanel.SetActive(false); // ������Ԃł͔�\��
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            choicePanel.SetActive(true); // �v���C���[���߂Â�����\��
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            choicePanel.SetActive(false); // ���ꂽ���\��
        }
    }
}