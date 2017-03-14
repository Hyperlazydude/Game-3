using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;

    private Rigidbody2D playerRB;
    private Player player;
    
    private void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
        this.player = this.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (this.player.movementEnabled)
        {
            float horizontal = this.player.GetAxis("Horizontal");
            this.playerRB.AddForce(Vector2.right * this.acceleration * horizontal);

            if (Mathf.Abs(this.playerRB.velocity.x) >= this.maxSpeed)
                this.playerRB.velocity = new Vector2(this.maxSpeed * horizontal, this.playerRB.velocity.y);
        }
    }
}