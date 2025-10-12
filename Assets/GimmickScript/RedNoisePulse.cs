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
                // �m�C�Y�̕\����؂�ւ���
                noiseImage.enabled = !noiseImage.enabled;

                // ���̐؂�ւ��܂ł̎��Ԃ������_���ɐݒ�
                nextPulseTime = Random.Range(pulseIntervalMin, pulseIntervalMax);
                timer = 0f;
            }
        }
        else
        {
            // �Ԃ���ʂ��I�������m�C�Y���\���ɂ��ă��Z�b�g
            noiseImage.enabled = false;
            timer = 0f;
            nextPulseTime = Random.Range(pulseIntervalMin, pulseIntervalMax);
        }
    }
}
