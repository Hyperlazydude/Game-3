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
    private bool jumpQueued;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
        this.playerManager = this.GetComponent<PlayerManager>();

        this.numJumps = 0;
        this.jumpQueued = false;
    }

    protected virtual void Update()
    {
        if (this.playerManager.movementEnabled && this.playerManager.GetButtonDown("Jump") && this.numJumps < this.AllowedJumps) 
            this.jumpQueued = true;
    }

    protected virtual void FixedUpdate()
    {
        if (this.jumpQueued)
        {
            this.numJumps++;

            Vector2 velocity = this.playerRB.velocity;
            if (velocity.y < 0)
                this.playerRB.velocity = new Vector2(velocity.x, this.jumpVelocity);
            else 
                this.playerRB.velocity += Vector2.up * this.jumpVelocity;
            this.jumpQueued = false;
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