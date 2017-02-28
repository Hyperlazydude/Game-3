using UnityEngine;

public class HorizontalController : MonoBehaviour
{

    public float maxSpeed;
    public float acceleration;

    protected Rigidbody2D playerRB;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        this.playerRB.AddForce(Vector2.right * this.acceleration * horizontal);

        if (Mathf.Abs(this.playerRB.velocity.x) >= this.maxSpeed)
            this.playerRB.velocity = new Vector2(this.maxSpeed * horizontal, this.playerRB.velocity.y);
        
    }
}