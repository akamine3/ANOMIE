using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    void Awake()
    {
        // すでに存在する場合は破棄（重複防止）
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // インスタンスを保持し、シーンを跨いでも破棄されないようにする
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}