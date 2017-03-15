using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private enum State
    {
        IDLE,
        TRACKING_PLAYERS,
        MOVING_TO_TRACK,
        MOVING_TO_POINT
    }

    private static CameraMovement instance;
    public static CameraMovement Instance
    {
        get { return CameraMovement.instance; }
    }

    public float buffer;
    
	private Transform player1Transform;
	private Transform player2Transform;
    
    private State currentState;

    private void Awake()
    {
        this.currentState = State.IDLE;

        CameraMovement.instance = this;
    }

    public void SetPlayerTransforms(Transform player1Transform, Transform player2Transform)
    {
        this.player1Transform = player1Transform;
        this.player2Transform = player2Transform;
    }
    
    public void TrackPlayers(float seconds)
    {
        this.currentState = State.MOVING_TO_TRACK;
        this.StartCoroutine(this.MoveCameraToPoint(this.CalMidpoint(), seconds, () => this.currentState = State.TRACKING_PLAYERS));
    }

    public void MoveToPoint(Vector3 point, float seconds)
    {
        this.currentState = State.MOVING_TO_POINT;
        this.StartCoroutine(this.MoveCameraToPoint(point, seconds, () => this.currentState = State.IDLE));
    }

	private void Update () {

        if (this.currentState == State.TRACKING_PLAYERS)
        {
            if (this.player1Transform != null && this.player2Transform != null)
                this.transform.position = this.CalMidpoint();
            else
                this.currentState = State.IDLE;
        }
	}
    
	private Vector3 CalMidpoint (){
		float x = (player1Transform.position.x + player2Transform.position.x) / 2;
		float y = (player1Transform.position.y + player2Transform.position.y) / 2;
		float z = -Mathf.Sqrt (Mathf.Pow(player1Transform.position.x - player2Transform.position.x, 2) + Mathf.Pow(player1Transform.position.y - player2Transform.position.y, 2)) - buffer;
		return new Vector3 (x, y, z);
	}

    private IEnumerator MoveCameraToPoint(Vector3 point, float seconds, System.Action callback)
    {
        point.z = -10;

        if (seconds <= 0)
            this.transform.position = point;
        else
        {
            Vector3 initialPosition = this.transform.position;
            float startTime = Time.time;

            for (float timeElapsed = 0; timeElapsed < seconds; timeElapsed = Time.time - startTime)
            {
                float elapsedRatio = timeElapsed / seconds;

                float x = Mathf.SmoothStep(initialPosition.x, point.x, elapsedRatio);
                float y = Mathf.SmoothStep(initialPosition.y, point.y, elapsedRatio);
                float z = Mathf.SmoothStep(initialPosition.z, point.z, elapsedRatio);

                this.transform.position = new Vector3(x, y, z);
                yield return null;
            }
        }

        if (callback != null)
            callback.Invoke();
    }
}
