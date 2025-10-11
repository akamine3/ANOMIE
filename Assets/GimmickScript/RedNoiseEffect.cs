using UnityEngine;
using UnityEngine.UI;

public class RedNoiseEffect : MonoBehaviour
{
    public RawImage noiseImage;
    public SanityEffect sanityEffect;

    void Update()
    {
        // 赤い画面演出中だけノイズ表示
        noiseImage.enabled = sanityEffect.IsEffectActive();
    }
}