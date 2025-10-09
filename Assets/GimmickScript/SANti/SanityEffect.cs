using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SanityEffect : MonoBehaviour
{
    public SanityManager sanityManager;
    public Image redOverlay;
    public float triggerThreshold = 30f;
    public float effectDuration = 5f;

    void Start()
    {
        StartCoroutine(CheckSanityEffect());
    }

    IEnumerator CheckSanityEffect()
    {
        while (true)
        {
            if (sanityManager.currentSanity <= triggerThreshold)
            {
                float waitTime = Random.Range(5f, 15f);
                yield return new WaitForSeconds(waitTime);
                StartCoroutine(ShowRedOverlay());
            }
            yield return null;
        }
    }

    IEnumerator ShowRedOverlay()
    {
        redOverlay.enabled = true;
        yield return new WaitForSeconds(effectDuration);
        redOverlay.enabled = false;
    }
}
