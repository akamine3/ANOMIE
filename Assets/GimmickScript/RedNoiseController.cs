using UnityEngine;
using UnityEngine.UI;

public class RedNoiseController : MonoBehaviour
{
    public RawImage noiseImage;
    public SanityEffect sanityEffect;

    public float pulseIntervalMin = 5f;
    public float pulseIntervalMax = 10f;

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
                // �m�C�Y�̕\����؂�ւ���
                noiseImage.enabled = !noiseImage.enabled;

                // ���̐؂�ւ��܂ł̎��Ԃ������_���ɐݒ�
                nextPulseTime = Random.Range(pulseIntervalMin, pulseIntervalMax);
                timer = 5f;
            }
        }
        else
        {
            noiseImage.enabled = false;
            timer = 0f;
            nextPulseTime = Random.Range(pulseIntervalMin, pulseIntervalMax);
        }
    }
}