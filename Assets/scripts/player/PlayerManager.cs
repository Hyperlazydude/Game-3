using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerNumber;

    [HideInInspector]
    public bool movementEnabled;

    [HideInInspector]
    public bool abilityEnabled;

    private void Awake()
    {
        this.movementEnabled = true;
        this.abilityEnabled = true;
    }

    public bool GetButtonDown(string button)
    {
        return Input.GetButtonDown(button + this.playerNumber);
    }

    public float GetAxis(string axis)
    {
        return Input.GetAxis(axis + this.playerNumber);
    }
}
