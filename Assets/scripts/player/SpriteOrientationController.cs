using UnityEngine;

public class SpriteOrientationController : MonoBehaviour
{
    private Rigidbody2D entityRB;
    private Transform entityTransform;

    [HideInInspector]
    public short lastOrientation;

    private void Awake()
    {
        this.entityRB = this.GetComponent<Rigidbody2D>();
        this.entityTransform = this.GetComponent<Transform>();

        this.lastOrientation = 1;
    }

    private void FixedUpdate()
    {
        short currentOrientation = (short) this.entityRB.velocity.x;
        short orientationSign = (short)Mathf.Sign(currentOrientation);

        if (currentOrientation != 0 && this.lastOrientation != orientationSign)
        {
            this.lastOrientation = orientationSign;
            this.entityTransform.localScale = Vector3.Scale(this.entityTransform.localScale, new Vector3(-1, 1, 1));
        }
    }
}