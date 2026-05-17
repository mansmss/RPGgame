using UnityEngine;

public class EnemyMeleeAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float health = 50f;
    public float attackRange = 1.2f;

    private Transform player;

    public float damage = 15f;

    void Update()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                return;
            }
        }

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distance > attackRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
{
    PlayerHealth player =
        collision.gameObject.GetComponent<PlayerHealth>();

    if (player != null)
    {
        player.TakeDamage(damage * Time.deltaTime);
    }
}
}