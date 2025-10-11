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
        // セーブデータがあるか確認してロード（仮）
        /*if (SaveManager.HasSaveData())
        {
            SaveManager.LoadGame();
        }
        else
        {
            Debug.Log("セーブデータがありません。");
        }*/
    }
}