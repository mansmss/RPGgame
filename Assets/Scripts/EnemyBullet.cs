using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 2f;

    public bool reflected;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!reflected)
        {
            PlayerHealth player =
                collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);

                Destroy(gameObject);

                return;
            }
        }

        if (reflected)
        {
            EnemyMeleeAI meleeEnemy =
                collision.GetComponentInParent<EnemyMeleeAI>();

            if (meleeEnemy != null)
            {
                meleeEnemy.TakeDamage(damage);

                Destroy(gameObject);

                return;
            }

            EnemyRangedAI rangedEnemy =
                collision.GetComponentInParent<EnemyRangedAI>();

            if (rangedEnemy != null)
            {
                rangedEnemy.TakeDamage(damage);

                Destroy(gameObject);

                return;
            }
        }
    }
}