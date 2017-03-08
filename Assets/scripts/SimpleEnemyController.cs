using System.Linq;
using UnityEngine;
using System.Collections;

public class SimpleEnemyController : MonoBehaviour {

    public float stunSeconds;
    public float enemySpeed;

    private bool Attached
    {
        get { return this.platformBounds != null; }
    }

    private Rigidbody2D enemyRB;
    private Collider2D enemyCollider;

    private Bounds platformBounds;
    private Vector3 localTransform;

    private bool direction;
    
    private void Awake()
    {
        this.enemyRB = this.GetComponent<Rigidbody2D>();
        this.enemyCollider = this.GetComponent<Collider2D>();

        this.localTransform = new Vector2();

        this.direction = true;
    }

    private void FixedUpdate()
    {
        if (this.Attached)
        {
            
            //velocity.x = this.enemySpeed * (this.direction ? 1 : -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Enemy hits platform for first time.
        if (this.Attached && collision.collider.CompareTag("Platform"))
            this.AttachToPlatform(collision.collider);
        else if (collision.collider.CompareTag("Player"))
        {
            float enemyY, ignore;

            CollisionUtilities.GetBoundsYLimits(this.enemyCollider.bounds, out ignore, out enemyY);

            ContactPoint2D[] contacts = collision.contacts;
            float firstContactY = contacts.First().point.y;
            float lastContactY = contacts.Last().point.y;

            // Player hit the enemy on the top of the enemy's collision box.
            if (Mathf.Abs(firstContactY - enemyY) < 0.05 && Mathf.Abs(lastContactY - enemyY) < 0.05)
                this.PlayerJumpOnHead(collision.gameObject);

            // Player hit on side.
            else
                this.StartCoroutine(this.StunPlayer(collision.gameObject, this.stunSeconds));
        }

    }
    
    private void AttachToPlatform(Collider2D platformCollider)
    {
        this.platformBounds = platformCollider.bounds;
        this.localTransform = this.enemyCollider.bounds.center - this.platformBounds.center;
    }

    private void PlayerJumpOnHead(GameObject player)
    {
        JumpController jumpController = player.GetComponent<JumpController>();
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

        playerRB.AddForce(jumpController.jumpVelocity * Vector2.up * Time.deltaTime);
        Object.Destroy(this.gameObject);
    }

    private IEnumerator StunPlayer(GameObject player, float seconds)
    {
        Vulnerability vulnerablility = player.GetComponent<Vulnerability>();
        Collider2D playerCollider = player.GetComponent<Collider2D>();

        if (vulnerablility.IsVulnerable)
        {
            vulnerablility.MakeInvulnerable();
            Physics2D.IgnoreCollision(playerCollider, this.enemyCollider);
            yield return new WaitForSeconds(seconds);
            Physics2D.IgnoreCollision(playerCollider, this.enemyCollider, false);
        }
    }

}
