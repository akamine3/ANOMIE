using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public string sceneName;
    public SceneFader sceneFader; // Inspector�Őݒ�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �t�F�[�h���g���ăV�[���J��
            sceneFader.FadeToScene(sceneName);
            Debug.Log("Scene Changed with Fade");
        }
    }
}