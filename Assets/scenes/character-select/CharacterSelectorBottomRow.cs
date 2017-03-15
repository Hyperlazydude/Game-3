using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorBottomRow : MonoBehaviour {

    private static readonly Color ACTIVE_COLOR = new Vector4(1, 1, 1, 1);
    private static readonly Color INACTIVE_COLOR = new Vector4(1, 1, 1, 0.5f);

    public Image jumperImage;
    public Image bomberImage;
    public Image shooterImage;

    public void SetPlayerType(PlayerManager.PlayerType playerType)
    {
        this.jumperImage.color = CharacterSelectorBottomRow.INACTIVE_COLOR;
        this.bomberImage.color = CharacterSelectorBottomRow.INACTIVE_COLOR;
        this.shooterImage.color = CharacterSelectorBottomRow.INACTIVE_COLOR;
        
        switch (playerType)
        {
            case PlayerManager.PlayerType.JUMPER:
                this.jumperImage.color = CharacterSelectorBottomRow.ACTIVE_COLOR;
                break;
            case PlayerManager.PlayerType.BOMBER:
                this.bomberImage.color = CharacterSelectorBottomRow.ACTIVE_COLOR;
                break;
            case PlayerManager.PlayerType.SHOOTER:
                this.shooterImage.color = CharacterSelectorBottomRow.ACTIVE_COLOR;
                break;
        }
    }
    
}
