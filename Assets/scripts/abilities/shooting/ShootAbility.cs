using System.Collections;
using UnityEngine;

public class ShootAbility : MonoBehaviour {
    
	public Bullet bulletPrefab;

    public float speed;
	public float timeDelete;
	public float timeBetweenShots;

    private Transform playerTransform;
    private Player player;
    private Orientation playerOrientation;
    
	private void Awake () {
        this.playerTransform = this.GetComponent<Transform>();
        this.player = this.GetComponent<Player>();
        this.playerOrientation = this.GetComponent<Orientation>();
	}
	
	private void Update () {
		if (this.player.GetButtonDown ("Ability") && this.player.abilityEnabled) 
			this.StartCoroutine (this.Shoot ());
	}

    private IEnumerator Shoot()
    {
        this.player.abilityEnabled = false;

        // Get the orientation of the player to determine the direction in which the bullet will shoot.
        float shotButtonPushed = this.player.GetAxis("Ability");
        this.playerOrientation.SetOrientation(shotButtonPushed);
        short shotDirection = this.playerOrientation.LastOrientation;
        
        Vector3 bulletSpawnPosition = this.playerTransform.position + Vector3.right * shotDirection;
        Bullet newBullet = Object.Instantiate(bulletPrefab, bulletSpawnPosition, this.playerTransform.rotation) as Bullet;
		newBullet.speed = speed * shotDirection;

        // Destroy the bullet in timeDelete time.
        Object.Destroy(newBullet.gameObject, timeDelete);

        // Re-enable shooting after timeBetweenShots seconds.
        yield return new WaitForSeconds(this.timeBetweenShots);
        this.player.abilityEnabled = true;
    }
		
}
