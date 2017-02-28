using UnityEngine;

public class JumpController : MonoBehaviour
{

    public float jumpForce;

    private Rigidbody2D playerRB;

    private bool canJump;
    
    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();

        this.canJump = true;
    }

    protected virtual void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && this.canJump)
        {
            this.canJump = false;
            this.playerRB.AddForce(jumpForce * Vector2.up * Time.deltaTime);
        }

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        MonoBehaviour.print("grounded!");
        if (collision.CompareTag("Platform"))
            this.canJump = true;
    }
}