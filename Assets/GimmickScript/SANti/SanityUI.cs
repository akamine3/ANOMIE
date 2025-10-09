using UnityEngine;
using UnityEngine.UI;

public class SanityUI : MonoBehaviour
{
    public SanityManager sanityManager;
    public Slider sanitySlider;
    public Image fillImage; // Fill•”•ª‚ÌImage

    public RectTransform gaugeTransform;
    public float shakeThreshold = 10f;
    public float shakeIntensity = 2f;

    void Start()
    {
        sanitySlider.maxValue = sanityManager.maxSanity;
    }

    void Update()
    {
        float sanity = sanityManager.currentSanity;
        sanitySlider.value = sanityManager.currentSanity;


        // F‚Ì•ÏX
        if (sanity > 60f)
            fillImage.color = Color.green;
        else if (sanity > 30f)
            fillImage.color = Color.yellow;
        else
            fillImage.color = Color.red;

        if (sanity <= shakeThreshold)
        {
            float shakeX = Random.Range(-shakeIntensity, shakeIntensity);
            float shakeY = Random.Range(-shakeIntensity, shakeIntensity);
            gaugeTransform.localPosition = new Vector3(shakeX, shakeY, 0);
        }
        else
        {
            gaugeTransform.localPosition = Vector3.zero;
        }

    }
}