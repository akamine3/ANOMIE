using UnityEngine;
using UnityEngine.UI;

public class RedNoiseDistortion : MonoBehaviour
{
    public RawImage noiseImage;
    public float distortionAmount = 0.01f;

    private Rect baseRect;

    void Start()
    {
        baseRect = noiseImage.uvRect;
    }

    void Update()
    {
        if (noiseImage.enabled)
        {
            float offsetX = Random.Range(-distortionAmount, distortionAmount);
            float offsetY = Random.Range(-distortionAmount, distortionAmount);
            noiseImage.uvRect = new Rect(baseRect.x + offsetX, baseRect.y + offsetY, baseRect.width, baseRect.height);
        }
        else
        {
            noiseImage.uvRect = baseRect;
        }
    }
}