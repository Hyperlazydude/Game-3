using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stun : MonoBehaviour {
	//public UnityEvent hit;
	public bool isVulnerable;
	public float stunDuration;
	private Animator anim;
	private MonoBehaviour[] scripts;
	private void Awake () {
		scripts = this.gameObject.GetComponents<MonoBehaviour> ();
		anim = GetComponent<Animator> ();
		isVulnerable = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	private void MakeVulnerable () {
		anim.SetTrigger ("Vulnerable");
		foreach (MonoBehaviour script in scripts) {
			script.enabled = true;
		}
		isVulnerable = true;

	}

	public void MakeInvulnerable () {
		anim.SetTrigger ("isVulnerable");
		isVulnerable = false;
		foreach (MonoBehaviour script in scripts) {
			script.enabled = false;
		}
		Invoke ("MakeVulnerable", stunDuration);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
