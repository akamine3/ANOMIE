using System.Collections;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public float maxSanity = 100f;
    public float currentSanity;
    public float decayRate = 0.5f;

    void Start()
    {
        currentSanity = maxSanity;
        StartCoroutine(SanityDecay());
    }

    IEnumerator SanityDecay()
    {
        while (true)
        {
            currentSanity -= decayRate;
            currentSanity = Mathf.Clamp(currentSanity, 0, maxSanity);
            yield return new WaitForSeconds(1f);
        }
    }

    public void ChangeSanity(float amount)
    {
        currentSanity += amount;
        currentSanity = Mathf.Clamp(currentSanity, 0, maxSanity);
    }
}
