using UnityEngine;

public class JumpController : MonoBehaviour
{

    public string jumpButtonName;
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
        if (Input.GetButtonDown(this.jumpButtonName) && this.canJump)
        {
            this.canJump = false;
            this.playerRB.AddForce(jumpForce * Vector2.up * Time.deltaTime);
        }

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Player"))
            this.canJump = true;
    }
}