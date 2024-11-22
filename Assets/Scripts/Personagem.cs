using UnityEngine;

public class Personagem : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]
    private bool isGrounded;
    private float checkRadius = 0.1f;
    public LayerMask groundLayer;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX,0) * moveSpeed;


        rb.linearVelocityX = movement.x * Time.deltaTime;


        animator.SetFloat("speed", Mathf.Abs(rb.linearVelocityX));


        HandleJump();


        if (moveX > 0)
        {
            Flip(false);
        }
        else if (moveX < 0)
        {
            Flip(true);
        }
    }
    private void HandleJump()
    {

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }


    private void Flip(bool flipToLeft)
    {

        Vector3 localScale = transform.localScale;
        localScale.x = flipToLeft ? -1f : 1f;
        transform.localScale = localScale;
    }
}
