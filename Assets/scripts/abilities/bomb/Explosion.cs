using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour {



	private void OnTriggerEnter2D(Collider2D collider)
	{
		Vulnerability vulnerability = collider.gameObject.GetComponent<Vulnerability>();
		if (vulnerability != null && vulnerability.IsVulnerable) {
			vulnerability.MakeInvulnerable();
		}
	}
}
