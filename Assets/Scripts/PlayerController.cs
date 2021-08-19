using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    void Start()
    {
        rb.gravityScale = 0;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.gravityScale = 3;
            rb.velocity = Vector2.up * speed;
        }
    }
}
