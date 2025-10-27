using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TavernTrigger : MonoBehaviour
{
    public GameObject enterButton; // UI�{�^��
    public string sceneName = "Past1 SAKABA"; // �J�ڐ�V�[����

    void Start()
    {
        enterButton.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered tavern area");
            enterButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left tavern area");
            enterButton.SetActive(false);
        }
    }

    public void EnterTavern()
    {
        SceneManager.LoadScene(sceneName);
    }
}