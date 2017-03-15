using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpVelocity;

    protected Rigidbody2D playerRB;
    protected Player player;

    protected bool grounded;
    protected bool jumpQueued;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
        this.player = this.GetComponent<Player>();

        this.grounded = false;
        this.jumpQueued = false;
    }

    protected virtual void Update()
    {
        if (this.player.movementEnabled && this.player.GetButtonDown("Jump") && this.grounded) 
            this.jumpQueued = true;
    }

    protected virtual void FixedUpdate()
    {
        if (this.jumpQueued)
        {
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
                this.grounded = true;
                break;    
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
            case "Player":
                this.grounded = false;
                break;

        }
    }
}