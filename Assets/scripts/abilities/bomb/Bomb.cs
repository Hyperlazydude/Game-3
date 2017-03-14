using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour {
	public float detonationTime;
	public GameObject explosionPrefab;

	private float timer;
	private GameObject explosion;
	private Renderer bombRenderer;
	private void Awake () {
		timer = 0;
		bombRenderer = this.GetComponent<Renderer> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		if (timer >= detonationTime) {
			this.bombRenderer.enabled = false;
			explosion = Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
			Object.Destroy (explosion.gameObject, 0.5f);
			Destroy (this.gameObject);
		}
		timer += Time.deltaTime;
	}
}
