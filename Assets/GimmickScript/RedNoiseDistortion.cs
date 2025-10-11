using UnityEngine;
using UnityEngine.UI;

public class RedNoiseDistortion : MonoBehaviour
{
    public RawImage noiseImage;
    public SanityEffect sanityEffect;
    public float distortionAmount = 0.01f;

    private Rect baseRect;

    void Start()
    {
        baseRect = noiseImage.uvRect;
    }

    void Update()
    {
        if (sanityEffect.IsEffectActive())
        {
            noiseImage.enabled = true;

            // UV‚ğƒ‰ƒ“ƒ_ƒ€‚É—h‚ç‚µ‚Ä˜c‚İ‚ğ‰‰o
            float offsetX = Random.Range(-distortionAmount, distortionAmount);
            float offsetY = Random.Range(-distortionAmount, distortionAmount);
            noiseImage.uvRect = new Rect(baseRect.x + offsetX, baseRect.y + offsetY, baseRect.width, baseRect.height);
        }
        else
        {
            noiseImage.enabled = false;
            noiseImage.uvRect = baseRect; // Œ³‚É–ß‚·
        }
    }
}