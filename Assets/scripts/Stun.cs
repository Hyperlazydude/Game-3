using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stun : MonoBehaviour {
	//public UnityEvent hit;
	public bool isVulnerable;
	public float stunDuration;
	private HorizontalController movement;
	private Animator anim;

	private void Awake () {
		movement = GetComponent<HorizontalController> ();
		anim = GetComponent<Animator> ();
		isVulnerable = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	private void MakeVulnerable () {
		anim.SetTrigger ("Vulnerable");
		movement.enabled = true;
		isVulnerable = true;

	}

	public void MakeInvulnerable () {
		anim.SetTrigger ("isVulnerable");
		isVulnerable = false;
		movement.enabled = false;
		Invoke ("MakeVulnerable", stunDuration);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
