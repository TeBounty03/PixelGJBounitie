using UnityEngine;

public class Droplet_Splash : MonoBehaviour
{

    public Rigidbody2D Rigidbody;
    public float acceleration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<PlayerHealth_1>() != null)
            {
                PlayerHealth_1 playerHealth = collision.transform.GetComponent<PlayerHealth_1>();
                playerHealth.TakeDamage(1);
                Destroy(transform.gameObject);
            }
            else if (collision.transform.GetComponent<PlayerHealth_2>() != null)
            {
                PlayerHealth_2 playerHealth = collision.transform.GetComponent<PlayerHealth_2>();
                playerHealth.TakeDamage(1);
                Destroy(transform.gameObject);
            }

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
