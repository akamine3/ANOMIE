using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public string sceneName;
    public SceneFader sceneFader; // Inspectorで設定

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // フェードを使ってシーン遷移
            sceneFader.FadeToScene(sceneName);
            Debug.Log("Scene Changed with Fade");
        }
    }
}