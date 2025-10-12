using UnityEngine;
using UnityEngine.UI;

public class RedNoiseFlicker : MonoBehaviour
{
    public RawImage noiseImage;

    void Update()
    {
        if (noiseImage.enabled)
        {
            float alpha = Random.Range(0.2f, 0.5f);
            noiseImage.color = new Color(1f, 0f, 0f, alpha);
        }
    }
}