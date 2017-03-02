using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stun : MonoBehaviour {
	//public UnityEvent hit;
	public bool isVulnerable;
	public float stunDuration;
	private HorizontalController movement;
	private JumpController jump;
	private ShootAbility shoot;
	private Animator anim;

	private void Awake () {
		movement = GetComponent<HorizontalController> ();
		jump = GetComponent<JumpController> ();
		shoot = GetComponent<ShootAbility> ();
		anim = GetComponent<Animator> ();
		isVulnerable = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	private void MakeVulnerable () {
		anim.SetTrigger ("Vulnerable");
		movement.enabled = true;
		jump.enabled = true;
		shoot.enabled = true;
		isVulnerable = true;

	}

	public void MakeInvulnerable () {
		anim.SetTrigger ("isVulnerable");
		isVulnerable = false;
		movement.enabled = false;
		jump.enabled = false;
		shoot.enabled = false;
		Invoke ("MakeVulnerable", stunDuration);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
