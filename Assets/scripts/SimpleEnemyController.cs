using UnityEngine;

public class SimpleEnemyController : MonoBehaviour {
    
    public float enemySpeed;

    private bool Attached
    {
        get { return this.platformCollider != null; }
    }

    private Rigidbody2D enemyRB;
    private Collider2D enemyCollider;
    private Collider2D platformCollider;

    private int direction;
    
    private void Awake()
    {
        this.enemyRB = this.GetComponent<Rigidbody2D>();
        this.enemyCollider = this.GetComponent<Collider2D>();
        this.platformCollider = null;

        this.direction = 1;
    }

    private void FixedUpdate()
    {
        if (this.Attached)
        {
            if (!CollisionUtilities.FullyContactingPlatform(this.platformCollider.bounds, this.enemyCollider.bounds))
                this.direction *= -1;
            this.enemyRB.velocity = Vector2.right * this.enemySpeed * this.direction;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // First contact with platform.
        if (collision.collider.CompareTag("Platform"))
            this.platformCollider = collision.collider;
        else if (collision.collider.CompareTag("Player"))
            switch (CollisionUtilities.GetCollisionPosition(collision))
            {
                // Player hit the enemy on the top of the enemy's collision box.
                case CollisionUtilities.CollisionPosition.TOP:
                    this.PlayerJumpOnHead(collision.gameObject);
                    break;

                // Player hit on side.
                case CollisionUtilities.CollisionPosition.LEFT:
                case CollisionUtilities.CollisionPosition.RIGHT:
                    this.StunPlayer(collision.gameObject);
                    break;
            }
    }

    private void PlayerJumpOnHead(GameObject player)
    {
        JumpController jumpController = player.GetComponent<JumpController>();
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

        playerRB.velocity += jumpController.jumpVelocity * Vector2.up;
        Object.Destroy(this.gameObject);
    }

    private void StunPlayer(GameObject player)
    {
        Vulnerability vulnerablility = player.GetComponent<Vulnerability>();

        if (vulnerablility.IsVulnerable)
            vulnerablility.MakeInvulnerable();
    }

}
