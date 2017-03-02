using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour {
	public Bullet bullet;
	public float speed;
	public float timeDelete;
	public float timeBetweenShots;
	public Transform point;

	private float current;
	private Rigidbody2D playerRB;
	private HorizontalController player;
	private Vector3 orignal;
	private Vector3 rotate;
	// Use this for initialization
	void Awake () {
		current = timeBetweenShots;
		timeBetweenShots = 0;
		player = GetComponent<HorizontalController> ();
		playerRB = GetComponent<Rigidbody2D> ();
		orignal = point.position;
	}
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			timeBetweenShots -= Time.deltaTime;
			if (timeBetweenShots <= 0) {
				timeBetweenShots = current;
				Bullet newBullet = Instantiate (bullet, point.position, point.rotation) as Bullet;
				newBullet.speed = speed;
				Destroy (newBullet.gameObject, timeDelete);
			}
		} else {
			timeBetweenShots -= Time.deltaTime;
		}
	}
}
