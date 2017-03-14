using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpVelocity;

    private Rigidbody2D playerRB;
    private Player player;

    protected virtual int AllowedJumps
    {
        get { return 1; }
    }

    private int numJumps;
    private bool jumpQueued;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
        this.player = this.GetComponent<Player>();

        this.numJumps = 0;
        this.jumpQueued = false;
    }

    protected virtual void Update()
    {
        if (this.player.movementEnabled && this.player.GetButtonDown("Jump") && this.numJumps < this.AllowedJumps) 
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