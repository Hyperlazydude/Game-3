using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float buffer;

	private Transform player1;
	private Transform player2;
	private Vector3 midpoint;
	// Use this for initialization
	private void Awake () {
		player1 = GameObject.FindGameObjectWithTag ("Player 1").transform;
		player2 = GameObject.FindGameObjectWithTag ("Player 2").transform;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		midpoint = CalMidpoint();
		this.transform.position = midpoint;
	}

	private Vector3 CalMidpoint (){
		float x = (player1.position.x + player2.position.x) / 2;
		float y = (player1.position.y + player2.position.y) / 2;
		float z = -Mathf.Sqrt (Mathf.Pow(player1.position.x - player2.position.x, 2) + Mathf.Pow(player1.position.y - player2.position.y, 2)) - buffer;
		return new Vector3 (x, y, z);
	}
}
