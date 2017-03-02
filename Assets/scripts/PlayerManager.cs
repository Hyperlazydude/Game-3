using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerNumber;

    [HideInInspector]
    public bool movementEnabled;

    [HideInInspector]
    public bool abilityEnabled;

    public bool GetButtonDown(string button)
    {
        return Input.GetButtonDown(button + this.playerNumber);
    }
}
