using UnityEngine;

public class HorizontalController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;

    private Rigidbody2D playerRB;
    private PlayerManager playerManager;
    
    private void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
        this.playerManager = this.GetComponent<PlayerManager>();
    }

    private void FixedUpdate()
    {
        if (this.playerManager.movementEnabled)
        {
            float horizontal = this.playerManager.GetAxis("Horizontal");
            this.playerRB.AddForce(Vector2.right * this.acceleration * horizontal);

            if (Mathf.Abs(this.playerRB.velocity.x) >= this.maxSpeed)
                this.playerRB.velocity = new Vector2(this.maxSpeed * horizontal, this.playerRB.velocity.y);
        }
    }
}