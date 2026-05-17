using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f;
    public float lifeTime = 1.5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMeleeAI meleeEnemy =
            collision.GetComponent<EnemyMeleeAI>();

        if (meleeEnemy != null)
        {
            meleeEnemy.TakeDamage(damage);

            Destroy(gameObject);

            return;
        }

        EnemyRangedAI rangedEnemy =
            collision.GetComponent<EnemyRangedAI>();

        if (rangedEnemy != null)
        {
            rangedEnemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}