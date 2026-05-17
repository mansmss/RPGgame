using UnityEngine;

public class EnemyRangedAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float health = 40f;

    public float stopDistance = 6f;
    public float retreatDistance = 3f;

    public GameObject bulletPrefab;
    public float bulletSpeed = 8f;

    public float shootCooldown = 1.5f;

    private float shootTimer;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        shootTimer = shootCooldown;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        shootTimer -= Time.fixedDeltaTime;

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        Vector2 direction = (
            player.position - transform.position
        ).normalized;

        if (distance > stopDistance)
        {
            rb.linearVelocity = direction * moveSpeed;
        }
        else if (distance < retreatDistance)
        {
            rb.linearVelocity = -direction * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;

            if (shootTimer <= 0)
            {
                Shoot(direction);

                shootTimer = shootCooldown;
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            transform.position,
            Quaternion.identity
        );

        bullet.transform.right = direction;

        Rigidbody2D bulletRb =
            bullet.GetComponent<Rigidbody2D>();

        bulletRb.linearVelocity =
            direction * bulletSpeed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}