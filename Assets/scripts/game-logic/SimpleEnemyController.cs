using UnityEngine;

public class SimpleEnemyController : MonoBehaviour {
    
    public float enemySpeed;
    public float dropOutVelocity;

    private Rigidbody2D enemyRB;
    private Vector3 enemyOffset;
    private Collider2D enemyCollider;
    private Collider2D platformCollider;
    
    private int direction;
    private bool dead;
    
    private void Awake()
    {
        this.enemyRB = this.GetComponent<Rigidbody2D>();
        this.enemyCollider = this.GetComponent<Collider2D>();
        this.platformCollider = null;

        this.direction = 1;
        this.dead = false;
    }

    private void FixedUpdate()
    {
        if (this.platformCollider != null)
        {
            if (!CollisionUtilities.FullyContactingPlatform(this.platformCollider.bounds, this.enemyCollider.bounds))
                this.direction *= -1;

            this.enemyOffset += Vector3.right * this.direction * Time.deltaTime;
            this.enemyRB.position = this.platformCollider.bounds.center + this.enemyOffset;
        } else if (this.dead)
        {
            Vector3 positionInViewport = UnityEngine.Camera.main.WorldToViewportPoint(this.enemyRB.position);
            if (!new Rect(0, 0, 1, 1).Contains(positionInViewport))
                Object.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // First contact with platform.
        if (collision.collider.CompareTag("Platform"))
        {
            this.platformCollider = collision.collider;
            this.enemyOffset = (Vector3) this.enemyRB.position - this.platformCollider.bounds.center;
        }
            
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
        Jump jumpController = player.GetComponent<Jump>();
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

        playerRB.velocity += jumpController.jumpVelocity * Vector2.up;

        this.enemyRB.velocity += Vector2.up * this.dropOutVelocity;
        this.enemyCollider.isTrigger = true;
        this.platformCollider = null;
        this.dead = true;
    }

    private void StunPlayer(GameObject player)
    {
        Vulnerability vulnerablility = player.GetComponent<Vulnerability>();

        if (vulnerablility.IsVulnerable)
            vulnerablility.MakeInvulnerable();
    }
}
