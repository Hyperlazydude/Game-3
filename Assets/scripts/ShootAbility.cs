using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour {
	public string fireName;
	public Bullet bullet;
	public float speed;
	public float timeDelete;
	public float timeBetweenShots;
	public Transform point;

	private float current;
	// Use this for initialization
	void Awake () {
		current = timeBetweenShots;
		timeBetweenShots = 0;
	}
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis(fireName) == 1) {
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
