using System.Collections;
using UnityEngine;

public class BombAbility : MonoBehaviour {
	public Bomb bombPrefab;
	public float bombTime;

	private Player player;
	private Transform playerTransform;
    private Orientation playerOrientation;

	private void Awake () {
		this.player = this.GetComponent<Player> ();
		this.playerTransform = this.GetComponent<Transform>();
        this.playerOrientation = this.GetComponent<Orientation>(); 
	}
    
	private void Update () {
		if (this.player.GetButtonDown ("Ability") && this.player.abilityEnabled) 
			this.StartCoroutine (this.PlaceBomb());
	}

	private IEnumerator PlaceBomb()
	{
		this.player.abilityEnabled = false;

        float abilityDirection = this.player.GetAxis("Ability");
        this.playerOrientation.SetOrientation(abilityDirection);
        short abilityOrientation = this.playerOrientation.LastOrientation;

        Vector3 spawnPosition = this.playerTransform.position + Vector3.right * abilityOrientation; 
		Bomb newBomb = Object.Instantiate(bombPrefab, spawnPosition, this.playerTransform.rotation) as Bomb;
		newBomb.detonationTime = bombTime;
        
		yield return new WaitForSeconds(this.bombTime);
		this.player.abilityEnabled = true;
	}
    
}
