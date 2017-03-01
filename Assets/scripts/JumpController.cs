using UnityEngine;

public class JumpController : MonoBehaviour
{
    
    public string jumpButtonName;
    public float jumpForce;

    private Rigidbody2D playerRB;

    protected virtual int AllowedJumps
    {
        get { return 1; }
    }

    private int numJumps;
    private bool jumpPressed;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();

        this.numJumps = 0;
        this.jumpPressed = false;
    }

    protected virtual void Update()
    {
        this.jumpPressed = Input.GetButtonDown(this.jumpButtonName);
    }

    protected virtual void FixedUpdate()
    {
        if (this.jumpPressed && this.numJumps < this.AllowedJumps)
        {
            this.numJumps++;
            this.playerRB.AddForce(jumpForce * Vector2.up * Time.deltaTime);
            this.jumpPressed = false;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Player"))
            this.numJumps = 0;
    }
}