using UnityEngine;
using UnityEngine.UI;

public class RedNoisePulse : MonoBehaviour
{
    public RawImage noiseImage;
    public SanityEffect sanityEffect;

    public float pulseIntervalMin = 0.2f;
    public float pulseIntervalMax = 0.6f;

    private float timer = 0f;
    private float nextPulseTime = 0f;

    void Start()
    {
        nextPulseTime = Random.Range(pulseIntervalMin, pulseIntervalMax);
    }

    void Update()
    {
        if (sanityEffect.IsEffectActive())
        {
            timer += Time.deltaTime;

            if (timer >= nextPulseTime)
            {
                // ノイズの表示を切り替える
                noiseImage.enabled = !noiseImage.enabled;

                // 次の切り替えまでの時間をランダムに設定
                nextPulseTime = Random.Range(pulseIntervalMin, pulseIntervalMax);
                timer = 0f;
            }
        }
        else
        {
            // 赤い画面が終わったらノイズを非表示にしてリセット
            noiseImage.enabled = false;
            timer = 0f;
            nextPulseTime = Random.Range(pulseIntervalMin, pulseIntervalMax);
        }
    }
}
