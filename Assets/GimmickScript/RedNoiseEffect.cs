using UnityEngine;
using UnityEngine.UI;

public class RedNoiseEffect : MonoBehaviour
{
    public RawImage noiseImage;
    public SanityEffect sanityEffect;

    void Update()
    {
        // �Ԃ���ʉ��o�������m�C�Y�\��
        noiseImage.enabled = sanityEffect.IsEffectActive();
    }
}