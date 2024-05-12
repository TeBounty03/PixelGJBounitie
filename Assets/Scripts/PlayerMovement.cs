using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isJumping = true;
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        float characterVelocityX = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("SpeedX", characterVelocityX);

        //Animations de saut
        // animator.SetFloat("SpeedY", rb.velocity.y);
        // animator.SetBool("isGrounded", isGrounded);

        Flip(rb.velocity.x);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocityX)
    {
        if (_velocityX > 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if (_velocityX < -0.1f)
        {
            spriteRenderer.flipX = false;
        }

    }
}
