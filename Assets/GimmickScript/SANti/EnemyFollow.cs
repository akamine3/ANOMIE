using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public SanityEffect sanityEffect;

    void Update()
    {
        if (sanityEffect.IsEffectActive())
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
