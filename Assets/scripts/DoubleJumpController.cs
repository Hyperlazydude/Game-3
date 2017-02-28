using UnityEngine;

public class DoubleJumpController : MonoBehaviour
{

    public string jumpButtonName;
    public float jumpForce;

    private Rigidbody2D playerRB;

    private int numJumps;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();

        this.numJumps = 0;
    }

    protected virtual void FixedUpdate()
    {
        if (Input.GetButtonDown(this.jumpButtonName) && this.numJumps < 2)
        {
            this.numJumps++;
            this.playerRB.AddForce(Vector2.up * this.jumpForce * Time.deltaTime);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Player"))
            this.numJumps = 0;
    }
}