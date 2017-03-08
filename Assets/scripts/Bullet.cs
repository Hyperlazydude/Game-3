using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed;
	
	// Update is called once per frame
	private void Update () {
		this.transform.Translate (Vector2.right * speed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vulnerability vulnerability = collision.gameObject.GetComponent<Vulnerability>();
        if (vulnerability != null && vulnerability.IsVulnerable) {
            vulnerability.MakeInvulnerable();
            Object.Destroy(this.gameObject);
        }
    }
}
