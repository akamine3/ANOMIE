using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public string gameOverSceneName = "GameOver";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("[Enemy] �v���C���[�ɐڐG�B�Q�[���I�[�o�[��ʂ֑J�ځB");
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}