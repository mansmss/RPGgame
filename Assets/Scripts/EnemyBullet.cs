using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT");
        
        PlayerHealth player =
            collision.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}