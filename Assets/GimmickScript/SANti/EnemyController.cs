using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SanityEffect sanityEffect;
    public GameObject enemy;
    public float chaseDuration = 10f;

    private bool isChasing = false;

    void Update()
    {
        // �Ԃ���ʉ��o���ɓG���o��
        if (sanityEffect.IsEffectActive() && !isChasing)
        {
            enemy.SetActive(true);
            isChasing = true;
            StartCoroutine(ChaseTimer());
        }
    }

    IEnumerator ChaseTimer()
    {
        yield return new WaitForSeconds(chaseDuration);
        enemy.SetActive(false);
        isChasing = false;
    }
}