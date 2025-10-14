using UnityEngine;
using UnityEngine.UI;

public class RedNoiseFlicker : MonoBehaviour
{
    public RawImage noiseImage;
    public SanityEffect sanityEffect;
    public float flickerSpeed = 0.1f;

    void Update()
    {
        if (sanityEffect.IsEffectActive())
        {
            noiseImage.enabled = true;

            // Alpha‚ðƒ‰ƒ“ƒ_ƒ€‚É•Ï‰»‚³‚¹‚Ä‚¿‚ç‚Â‚«
            float alpha = Random.Range(0.2f, 0.5f);
            noiseImage.color = new Color(1f, 0f, 0f, alpha);
        }
        else
        {
            noiseImage.enabled = false;
        }
    }
}