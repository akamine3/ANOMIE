using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �Q�[���I�[�o�[�����i��F�V�[���ēǂݍ��݁j
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}