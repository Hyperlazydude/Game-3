using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private static CameraMovement instance;
    public static CameraMovement Instance
    {
        get { return CameraMovement.instance; }
    }

    public float buffer;
    
	private Transform player1Transform;
	private Transform player2Transform;

    private Vector3 midpoint;

    private void Awake()
    {
        CameraMovement.instance = this;
    }

    public void SetPlayerTransforms(Transform player1Transform, Transform player2Transform)
    {
        this.player1Transform = player1Transform;
        this.player2Transform = player2Transform;
    }

	private void Update () {
        if (this.player1Transform != null && this.player2Transform != null)
		    this.transform.position = this.CalMidpoint();
	}
    
	private Vector3 CalMidpoint (){
		float x = (player1Transform.position.x + player2Transform.position.x) / 2;
		float y = (player1Transform.position.y + player2Transform.position.y) / 2;
		float z = -Mathf.Sqrt (Mathf.Pow(player1Transform.position.x - player2Transform.position.x, 2) + Mathf.Pow(player1Transform.position.y - player2Transform.position.y, 2)) - buffer;
		return new Vector3 (x, y, z);
	}
}
