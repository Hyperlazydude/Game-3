using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	private Stun stun;
	// Use this for initialization

	private void Awake () {
		stun = GetComponent<Stun> ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Bullet") {
			Destroy(collision.gameObject);
			if (stun.isVulnerable) {
				stun.MakeInvulnerable ();
				//stun.hit.Invoke ();
			}
		}
	}
}
