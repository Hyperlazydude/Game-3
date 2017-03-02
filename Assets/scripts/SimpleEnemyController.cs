using System.Linq;
using UnityEngine;
using System.Collections;

public class SimpleEnemyController : MonoBehaviour {

    public float enemySpeed;

    private Rigidbody2D enemyRB;
    private Collider2D enemyCollider;
	private Stun stun;
    
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
        {
            Vector2 velocity = this.enemyRB.velocity;
            velocity.x = this.enemySpeed * (this.direction ? 1 : -1);
            this.enemyRB.velocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
            this.grounded = true;
        else if (collision.collider.CompareTag("Player"))
        {
            float enemyY, ignore;

            CollisionUtilities.GetBoundsYLimits(this.enemyCollider.bounds, out ignore, out enemyY);
            
            ContactPoint2D[] contacts = collision.contacts;
            float firstContactY = contacts.First().point.y;
            float lastContactY = contacts.Last().point.y;

			if (Mathf.Abs (firstContactY - enemyY) < 0.05 && Mathf.Abs (lastContactY - enemyY) < 0.05) {
				GameObject playerObject = collision.gameObject;

				JumpController jumpController = playerObject.GetComponent<JumpController> ();
				Rigidbody2D playerRB = playerObject.GetComponent<Rigidbody2D> ();

				playerRB.AddForce (jumpController.jumpForce * Vector2.up * Time.deltaTime);
				Object.Destroy (this.gameObject);
			} else {
				stun = collision.gameObject.GetComponent<Stun> ();
				if (stun.isVulnerable) {
					stun.MakeInvulnerable ();
					Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
					StartCoroutine (collisionOn (stun.stunDuration, collision));
				}
			}
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) {
            //Vector2 velocity = this.enemyRB.velocity;
            //velocity.y = collision.rigidbody.velocity.y;
            //this.enemyRB.velocity = velocity;
            if (!CollisionUtilities.FullyContactingPlatform(collision.collider.bounds, this.enemyCollider.bounds))
                this.direction = !this.direction;
        }
            
    }

	private IEnumerator collisionOn (float seconds, Collision2D collision) {
		yield return new WaitForSeconds (seconds);
		Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>(), false);
	}


}
