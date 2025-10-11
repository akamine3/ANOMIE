using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverFade : MonoBehaviour
{
    public Image fadeImage; // 黒いImage（Canvas上に配置）
    public float fadeDuration = 2f;
    public string gameOverSceneName = "GameOver";

    private bool isFading = false;

    public void StartFade()
    {
        if (!isFading)
        {
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        isFading = true;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(0f, 0f, 0f, 1f);
        SceneManager.LoadScene(gameOverSceneName);
    }
}