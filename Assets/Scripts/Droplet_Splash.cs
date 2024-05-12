using UnityEngine;

public class Droplet_Splash : MonoBehaviour
{

    public Rigidbody2D Rigidbody;
    public float acceleration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(transform.gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(transform.gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        Rigidbody.gravityScale += acceleration;
    }
}
