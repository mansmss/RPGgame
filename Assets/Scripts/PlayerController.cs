using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        RotateToMouse();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    void RotateToMouse()
{
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    Vector3 scale = transform.localScale;

    if (mousePosition.x < transform.position.x)
    {
        scale.x = -0.75f;
    }
    else
    {
        scale.x = 0.75f;
    }

    transform.localScale = scale;
}
}