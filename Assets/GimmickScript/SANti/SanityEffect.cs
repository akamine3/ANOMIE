using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SanityEffect : MonoBehaviour
{
    public SanityManager sanityManager;
    public Image redOverlay;
    public float triggerThreshold = 30f;
    public float effectDuration = 10f;

    private bool isEffectActive = false;

    void Start()
    {
        StartCoroutine(CheckSanityEffect());
        sanityManager = SanityManager.Instance;
    }

    IEnumerator CheckSanityEffect()
    {
        while (true)
        {
            // SAN値が低く、演出がまだ始まっていない場合のみ処理
            if (!isEffectActive && sanityManager.currentSanity <= triggerThreshold)
            {
                float waitTime = Random.Range(5f, 15f);
                Debug.Log($"[SanityEffect] SAN値が低下（{sanityManager.currentSanity}）。{waitTime}秒後に赤い画面演出を開始予定。");

                // ランダム待機中にSAN値が回復したらキャンセル
                float elapsed = 0f;
                while (elapsed < waitTime)
                {
                    if (sanityManager.currentSanity > triggerThreshold)
                    {
                        Debug.Log("[SanityEffect] SAN値が回復したため赤い画面演出をキャンセル。");
                        yield return null;
                        break;
                    }
                    elapsed += Time.deltaTime;
                    yield return null;
                }

                // SAN値がまだ低ければ演出開始
                if (sanityManager.currentSanity <= triggerThreshold)
                {
                    StartCoroutine(ShowRedOverlay());
                }
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
