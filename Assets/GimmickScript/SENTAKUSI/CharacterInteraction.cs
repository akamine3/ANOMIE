using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public GameObject choicePanel; // 選択肢ボタンが入ったUIパネル

    void Start()
    {
        choicePanel.SetActive(false); // 初期状態では非表示
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            choicePanel.SetActive(true); // プレイヤーが近づいたら表示
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            choicePanel.SetActive(false); // 離れたら非表示
        }
    }
}