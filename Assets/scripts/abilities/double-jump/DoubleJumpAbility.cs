public class DoubleJumpAbility : Jump
{
    private bool airJumped;

    protected override void Awake()
    {
        base.Awake();
        this.airJumped = false;
        this.player.abilityEnabled = false;
    }

    protected override void Update()
    {
        this.player.abilityEnabled = false;

        if (this.grounded)
        {
            this.airJumped = false;
            base.Update();
            return;
        }

        if (this.player.movementEnabled && !this.airJumped && this.playerRB.velocity.y <= 0)
        {
            this.player.abilityEnabled = true;

            if (this.player.GetButtonDown("Jump"))
            {
                this.jumpQueued = true;
                this.airJumped = true;
                this.player.abilityEnabled = false;
            }
        }
            
    }
}