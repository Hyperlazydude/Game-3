using System.Collections;
using UnityEngine;

public class ShootAbility : MonoBehaviour {
    
	public Bullet bulletPrefab;

    public float speed;
	public float timeDelete;
	public float timeBetweenShots;

    private Transform playerTransform;
    private PlayerManager playerManager;
    
	private void Awake () {
        this.playerTransform = this.GetComponent<Transform>();
        this.playerManager = this.GetComponent<PlayerManager>();
	}
	
	private void Update () {
        if (this.playerManager.GetButtonDown("Ability") && this.playerManager.abilityEnabled)
            this.StartCoroutine(this.Shoot());
	}

    private IEnumerator Shoot()
    {
        this.playerManager.abilityEnabled = false;

        // Get the orientation of the player to determine the direction in which the bullet will shoot.
        short orientation = this.GetComponent<SpriteOrientationController>().lastOrientation;
        
        Vector3 bulletSpawnPosition = this.playerTransform.position + Vector3.right * orientation;
        Bullet newBullet = Object.Instantiate(bulletPrefab, bulletSpawnPosition, this.playerTransform.rotation) as Bullet;
        newBullet.speed = speed * orientation;

        // Destroy the bullet in timeDelete time.
        Object.Destroy(newBullet.gameObject, timeDelete);

        // Re-enable shooting after timeBetweenShots seconds.
        yield return new WaitForSeconds(this.timeBetweenShots);
        this.playerManager.abilityEnabled = true;
    }
}
