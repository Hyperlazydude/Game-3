using System.Collections;
using UnityEngine;

public class BombAbility : MonoBehaviour {
	public Bomb bombPrefab;
	public float bombTime;

	private PlayerManager playerManager;
	private Transform playerTransform;

	private void Awake () {
		this.playerManager = this.GetComponent<PlayerManager> ();
		this.playerTransform = this.GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	private void Update () {
		if (this.playerManager.GetButtonDown ("Ability") && this.playerManager.abilityEnabled) 
			this.StartCoroutine (this.PlaceBomb ());
	}

	private IEnumerator PlaceBomb()
	{
		this.playerManager.abilityEnabled = false;

		Vector3 spawnPosition = SpawnLocation();
		Bomb newBomb = Object.Instantiate(bombPrefab, spawnPosition, this.playerTransform.rotation) as Bomb;
		newBomb.detonationTime = bombTime;

		//Destroy the bullet in timeDelete time.

		//Re-enable shooting after timeBetweenShots seconds.
		yield return new WaitForSeconds(this.bombTime);
		this.playerManager.abilityEnabled = true;
	}

	private Vector3 SpawnLocation()
	{
		if (playerManager.GetAxis ("Ability") > 0) {
			this.playerTransform.localScale = new Vector3 (Mathf.Abs (playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
		} else {
			this.playerTransform.localScale = new Vector3 (-Mathf.Abs (playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
		}
		return this.playerTransform.position + Vector3.right * Mathf.Sign(playerTransform.localScale.x);
	}
}
