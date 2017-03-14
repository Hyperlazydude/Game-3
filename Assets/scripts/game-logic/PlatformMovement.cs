using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
	public Vector3 dest;
	public float movementSpeed;

	private Vector3 current;
	private Vector3 move;
	// Use this for initialization
	void Awake () {
		current = transform.position;
		move = dest;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, move, movementSpeed * Time.deltaTime);
		if (transform.position == move) {
			move = current;
		}
		if (transform.position == current) {
			move = dest;
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
            case "Enemy":
                if (CollisionUtilities.GetCollisionPosition(collision) == CollisionUtilities.CollisionPosition.TOP)
                    collision.transform.parent = this.transform;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.parent = null;
    }
}
