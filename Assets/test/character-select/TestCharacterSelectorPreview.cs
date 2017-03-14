using UnityEngine;
using UnityEngine.UI;

public class TestCharacterSelectorPreview : MonoBehaviour {

    private static readonly string JUMPER_DESCRIPTION = "A robot that can jump in midair, at the apex of its jump.";
    private static readonly string SHOOTER_DESCRIPTION = "A robot that can shoot projectiles that will temporarily stun enemies.";
    private static readonly string BOMBER_DESCRIPTION = "A robot that can drop bombs that push away and stun enemy robots.";

    public GameObject jumperPreview;
    public GameObject shooterPreview;
    public GameObject bomberPreview;

    public Text previewTitle;
    public Text previewDescription;
    
    public void SetPlayerType(PlayerManager.PlayerType playerType)
    {
        this.jumperPreview.SetActive(false);
        this.shooterPreview.SetActive(false);
        this.bomberPreview.SetActive(false);

        this.previewTitle.text = playerType.ToString();
        switch (playerType)
        {
            case PlayerManager.PlayerType.JUMPER:
                this.jumperPreview.SetActive(true);
                this.previewDescription.text = JUMPER_DESCRIPTION;
                break;
            case PlayerManager.PlayerType.SHOOTER:
                this.shooterPreview.SetActive(true);
                this.previewDescription.text = SHOOTER_DESCRIPTION;
                break;
            case PlayerManager.PlayerType.BOMBER:
                this.bomberPreview.SetActive(true);
                this.previewDescription.text = BOMBER_DESCRIPTION;
                break;
        }
    }
}
