using UnityEngine;

public class Droplet_Splash : MonoBehaviour
{

    public Rigidbody2D Rigidbody;
    // public Vector2 speed;
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



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.gravityScale += acceleration;
        // Rigidbody.AddForce(speed);
    }
}
