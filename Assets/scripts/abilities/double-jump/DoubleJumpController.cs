using UnityEngine;

public class DoubleJumpController : JumpController
{
    protected override int AllowedJumps
    {
        get { return 2; }
    }
}