using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public string gameOverSceneName = "GameOver";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("[Enemy] プレイヤーに接触。ゲームオーバー画面へ遷移。");
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}