using System.Collections;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemy;
    public float chaseDuration = 10f;
    public SanityEffect sanityEffect;

    private bool isChasing = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isChasing && sanityEffect.IsEffectActive() && other.CompareTag("Player"))
        {
            enemy.SetActive(true);
            isChasing = true;
            StartCoroutine(ChasePlayer());
        }
    }

    IEnumerator ChasePlayer()
    {
        // ‚±‚±‚Å“G‚Ì’ÇÕAI‚ğ—LŒø‰»i–¢À‘•‚È‚ç‰¼‚ÅˆÚ“®ˆ—j
        yield return new WaitForSeconds(chaseDuration);
        enemy.SetActive(false);
        isChasing = false;
    }
}