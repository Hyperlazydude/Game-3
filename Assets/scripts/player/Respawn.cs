using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float respawnGhostTime;
    
    private Collider2D playerCollider;
    private Rigidbody2D playerRB;

    private Collider2D lastPlatformCollider; 
    private Vector3 lastOffset;
    
    private bool respawn;

    private void Awake()
    {
        this.playerCollider = this.GetComponent<Collider2D>();
        this.playerRB = this.GetComponent<Rigidbody2D>();

        this.lastPlatformCollider = null;
        this.lastOffset = this.playerRB.position;

        this.respawn = false;
    }
    
    private void FixedUpdate()
    {
        if (this.respawn)
        {
            this.playerRB.position = this.lastPlatformCollider.bounds.center + this.lastOffset;
            this.playerRB.velocity = Vector2.zero;

            this.GetComponent<Vulnerability>().MakeInvulnerable();
            this.respawn = false; 
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (
            collision.gameObject.CompareTag("Platform") &&
            CollisionUtilities.GetCollisionPosition(collision) == CollisionUtilities.CollisionPosition.BOTTOM &&
            CollisionUtilities.FullyContactingPlatform(collision.collider.bounds, this.playerCollider.bounds, 0.25f)
        )
        {
            if (collision.collider != this.lastPlatformCollider)
                this.lastPlatformCollider = collision.collider;
            this.lastOffset = this.transform.position - this.lastPlatformCollider.bounds.center;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death Barrier"))
            this.respawn = true;      
    }
    
}