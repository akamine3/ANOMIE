using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void OnReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnContinue()
    {
        // �Z�[�u�f�[�^�����邩�m�F���ă��[�h�i���j
        /*if (SaveManager.HasSaveData())
        {
            SaveManager.LoadGame();
        }
        else
        {
            Debug.Log("�Z�[�u�f�[�^������܂���B");
        }*/
    }
}