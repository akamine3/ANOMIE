using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            // �v���C���[�̌��݈ʒu��ۑ�
            //ScenePositionManager.returnPosition = other.transform.position;


            SceneManager.LoadScene(sceneName);
            Debug.Log("Scene Changed");
        }
    }

}
