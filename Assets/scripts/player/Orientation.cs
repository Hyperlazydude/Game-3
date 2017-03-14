using UnityEngine;

public class Orientation : MonoBehaviour
{
    private Rigidbody2D entityRB;
    private Transform entityTransform;
    
    private short lastOrientation;
    public short LastOrientation
    {
        get { return this.lastOrientation; }
    }

    public void SetOrientation(float direction)
    {
        short newOrientation = (short)direction;
        short orientationSign = (short)Mathf.Sign(newOrientation);

        if (newOrientation != 0 && this.lastOrientation != orientationSign)
        {
            this.lastOrientation = orientationSign;
            this.entityTransform.localScale = Vector3.Scale(this.entityTransform.localScale, new Vector3(-1, 1, 1));
        }
    }

    private void Awake()
    {
        this.entityRB = this.GetComponent<Rigidbody2D>();
        this.entityTransform = this.GetComponent<Transform>();

        this.lastOrientation = 1;
    }

    private void FixedUpdate()
    {
        this.SetOrientation(this.entityRB.velocity.x);
    }
}