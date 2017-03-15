public class DoubleJumpAbility : Jump
{
    private bool airJumped;

    protected override void Awake()
    {
        base.Awake();
        this.player.abilityEnabled = false;
    }
    protected override void Update()
    {
        if (this.grounded)
        {
            this.player.abilityEnabled = true;
            base.Update();
        }
        else if (this.player.movementEnabled && this.player.abilityEnabled && this.player.GetButtonDown("Jump") && this.playerRB.velocity.y <= 0)
        {
            this.jumpQueued = true;
            this.player.abilityEnabled = false;
        }   
    }
}