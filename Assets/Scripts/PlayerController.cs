using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip playerMovementSound;
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb.gravityScale = 0;
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameObject.GetComponent<Collision>().isGameOver)
        {
            rb.gravityScale = 3;
            audioSource.PlayOneShot(playerMovementSound);
            rb.velocity = Vector2.up * speed;
        }
    }
}
