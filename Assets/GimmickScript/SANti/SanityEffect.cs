using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SanityEffect : MonoBehaviour
{
    public SanityManager sanityManager;
    public Image redOverlay;
    public float triggerThreshold = 30f;
    public float effectDuration = 10f;

    private bool isEffectActive = false;

    void Start()
    {
        StartCoroutine(CheckSanityEffect());
        sanityManager = SanityManager.Instance;
    }

    IEnumerator CheckSanityEffect()
    {
        while (true)
        {
            // SAN�l���Ⴍ�A���o���܂��n�܂��Ă��Ȃ��ꍇ�̂ݏ���
            if (!isEffectActive && sanityManager.currentSanity <= triggerThreshold)
            {
                float waitTime = Random.Range(5f, 15f);
                Debug.Log($"[SanityEffect] SAN�l���ቺ�i{sanityManager.currentSanity}�j�B{waitTime}�b��ɐԂ���ʉ��o���J�n�\��B");

                // �����_���ҋ@����SAN�l���񕜂�����L�����Z��
                float elapsed = 0f;
                while (elapsed < waitTime)
                {
                    if (sanityManager.currentSanity > triggerThreshold)
                    {
                        Debug.Log("[SanityEffect] SAN�l���񕜂������ߐԂ���ʉ��o���L�����Z���B");
                        yield return null;
                        break;
                    }
                    elapsed += Time.deltaTime;
                    yield return null;
                }

                // SAN�l���܂��Ⴏ��Ή��o�J�n
                if (sanityManager.currentSanity <= triggerThreshold)
                {
                    StartCoroutine(ShowRedOverlay());
                }
            }

            yield return null;
        }
    }

    IEnumerator ShowRedOverlay()
    {
        isEffectActive = true;
        Debug.Log("[SanityEffect] �Ԃ���ʉ��o���J�n�B");
        redOverlay.enabled = true;

        yield return new WaitForSeconds(effectDuration);

        redOverlay.enabled = false;
        isEffectActive = false;
        Debug.Log("[SanityEffect] �Ԃ���ʉ��o���I���B");
    }

    public bool IsEffectActive()
    {
        return isEffectActive;
    }
}
