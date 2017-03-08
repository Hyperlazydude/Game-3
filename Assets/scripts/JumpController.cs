using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpVelocity;

    private Rigidbody2D playerRB;
    private PlayerManager playerManager;

    protected virtual int AllowedJumps
    {
        get { return 1; }
    }

    private int numJumps;
    private bool jumpPressed;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
        this.playerManager = this.GetComponent<PlayerManager>();

        this.numJumps = 0;
        this.jumpPressed = false;
    }

    protected virtual void Update()
    {
        this.jumpPressed = this.playerManager.GetButtonDown("Jump");
    }

    protected virtual void FixedUpdate()
    {
        if (this.playerManager.movementEnabled && this.jumpPressed && this.numJumps < this.AllowedJumps)
        {
            this.numJumps++;
            this.playerRB.velocity += Vector2.up * this.jumpVelocity;
            this.jumpPressed = false;
        }
    }

    protected void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
            case "Player":
                this.numJumps = 0;
                break;    
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
            case "Player":
                this.numJumps = 1;
                break;

        }
    }
}