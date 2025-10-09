using System.Collections;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemy;
    public float chaseDuration = 10f;
    public SanityEffect sanityEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (sanityEffect.redOverlay.enabled && other.CompareTag("Player"))
        {
            enemy.SetActive(true);
            StartCoroutine(ChasePlayer());
        }
    }

    IEnumerator ChasePlayer()
    {
        // �����œG�̒ǐ�AI��L����
        yield return new WaitForSeconds(chaseDuration);
        enemy.SetActive(false);
    }
}