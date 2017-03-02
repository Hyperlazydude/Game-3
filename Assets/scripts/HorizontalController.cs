using UnityEngine;

public class HorizontalController : MonoBehaviour
{

    public string horizontalAxisName;

    public float maxSpeed;
    public float acceleration;

    protected Rigidbody2D playerRB;
	protected bool right = true;

    protected virtual void Awake()
    {
        this.playerRB = this.GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        float horizontal = Input.GetAxis(this.horizontalAxisName);
		flip (horizontal);
        this.playerRB.AddForce(Vector2.right * this.acceleration * horizontal);

        if (Mathf.Abs(this.playerRB.velocity.x) >= this.maxSpeed)
            this.playerRB.velocity = new Vector2(this.maxSpeed * horizontal, this.playerRB.velocity.y);
        
    }
	protected void flip (float horizontal){
		if (horizontal < 0 && right == true) {
			right = !right;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
		if (horizontal > 0 && right == false) {
			right = !right;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}
}