using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ゲームオーバー処理（例：シーン再読み込み）
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}