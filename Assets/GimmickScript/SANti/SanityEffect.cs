using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SanityEffect : MonoBehaviour
{
    public SanityManager sanityManager;
    public Image redOverlay;
    public float triggerThreshold = 30f;
    public float effectDuration = 5f;

    private bool isEffectActive = false;

    void Start()
    {
        StartCoroutine(CheckSanityEffect());
        redOverlay.enabled = false;
    }

    IEnumerator CheckSanityEffect()
    {
        while (true)
        {
            if (!isEffectActive && sanityManager.currentSanity <= triggerThreshold)
            {
                float waitTime = Random.Range(5f, 15f);
                Debug.Log($"[SanityEffect] SAN値が低下（{sanityManager.currentSanity}）。{waitTime}秒後に赤い画面演出を開始予定。");
                yield return new WaitForSeconds(waitTime);
                StartCoroutine(ShowRedOverlay());
            }
            yield return null;
        }
    }

    IEnumerator ShowRedOverlay()
    {
        isEffectActive = true;
        Debug.Log("[SanityEffect] 赤い画面演出を開始。");
        redOverlay.enabled = true;

        yield return new WaitForSeconds(effectDuration);

        redOverlay.enabled = false;
        isEffectActive = false;
        Debug.Log("[SanityEffect] 赤い画面演出を終了。");
    }

    public bool IsEffectActive()
    {
        return isEffectActive;
    }
}
