using System.Linq;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour {

    public float enemySpeed;

    private Rigidbody2D enemyRB;
    private Collider2D enemyCollider;
    
    private bool direction;

    private bool grounded;

    private void Awake()
    {
        this.enemyRB = this.GetComponent<Rigidbody2D>();
        this.enemyCollider = this.GetComponent<Collider2D>();

        this.direction = true;
        this.grounded = false;
    }

    private void FixedUpdate()
    {
        if (this.grounded)
            this.enemyRB.MovePosition(this.enemyRB.position + Vector2.right * this.enemySpeed * (this.direction ? 1 : -1) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
            this.grounded = true;
        else if (collision.collider.CompareTag("Player"))
        {
            GameObject playerObject = collision.gameObject;

            JumpController jumpController = playerObject.GetComponent<JumpController>();
            Rigidbody2D playerRB = playerObject.GetComponent<Rigidbody2D>();

            playerRB.AddForce(jumpController.jumpForce * Vector2.up * Time.deltaTime);
            Object.Destroy(this.gameObject);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (
            collision.gameObject.CompareTag("Platform") && 
            !CollisionUtilities.FullyContactingPlatform(collision.collider.bounds, this.enemyCollider.bounds)
        )
            this.direction = !this.direction;
    }

}
