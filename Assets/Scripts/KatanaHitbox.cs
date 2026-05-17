using UnityEngine;

public class KatanaHitbox : MonoBehaviour
{
    public float damage = 50f;
    public float healAmount = 15f;

    private PlayerHealth playerHealth;

    private Collider2D hitboxCollider;

    void Awake()
    {
        playerHealth =
            GetComponentInParent<PlayerHealth>();

        hitboxCollider =
            GetComponent<Collider2D>();

        hitboxCollider.enabled = false;
    }

    public void ActivateHitbox()
    {
        hitboxCollider.enabled = true;
    }

    public void DeactivateHitbox()
    {
        hitboxCollider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMeleeAI meleeEnemy =
            collision.GetComponentInParent<EnemyMeleeAI>();

        if (meleeEnemy != null)
        {
            meleeEnemy.TakeDamage(damage);

            HealPlayer();

            return;
        }

        EnemyRangedAI rangedEnemy =
            collision.GetComponentInParent<EnemyRangedAI>();

        if (rangedEnemy != null)
        {
            rangedEnemy.TakeDamage(damage);

            HealPlayer();

            return;
        }

        EnemyBullet enemyBullet =
            collision.GetComponent<EnemyBullet>();

        if (enemyBullet != null)
        {
            ReflectBullet(enemyBullet.gameObject);
        }
    }

    void HealPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);
        }
    }

    void ReflectBullet(GameObject bullet)
    {
        EnemyBullet enemyBullet =
            bullet.GetComponent<EnemyBullet>();

        enemyBullet.reflected = true;

        Rigidbody2D rb =
            bullet.GetComponent<Rigidbody2D>();

        Vector2 direction =
            -bullet.transform.right;

        bullet.transform.right = direction;

        rb.linearVelocity = direction * 10f;
    }
}