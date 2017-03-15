using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public static void Show()
    {
        Array.ForEach(
            HUD.instances, 
            (instance) => instance.StartCoroutine(instance.canvasGroup.FadeAlpha(1.0f, 0.5f))
        );
    }

    public static void Hide()
    {
        Array.ForEach(
            HUD.instances, 
            (instance) => instance.StartCoroutine(instance.canvasGroup.FadeAlpha(0, 0.5f))
        );
    }

    private static readonly float ABILITY_ENABLED_ALPHA = 1;
    private static readonly float ABILITY_DISABLED_ALPHA = 0.5f;

    private static readonly HUD[] instances = new HUD[2];
    
    public int playerNumber;
    
    public Image jumperAbility;
    public Image bomberAbility;
    public Image shooterAbility;

    public GameObject jumperControls;
    public GameObject bomberControls;
    public GameObject shooterControls;
    
    public Image jumperImage;
    public Image bomberImage;
    public Image shooterImage;

    public Text points;
    public Text playerName;

    private CanvasGroup canvasGroup;

    private Image activeAbility;
    private Player player;

    private void Awake()
    {
        this.canvasGroup = this.GetComponent<CanvasGroup>();
        HUD.instances[this.playerNumber - 1] = this;
    }

    private void Start()
    {
        this.player = PlayerManager.Instance.GetPlayer(this.playerNumber);
        this.points.text = PointSystem.Instance.GetCurrentPoints(this.playerNumber).ToString();

        PlayerManager playerManager = PlayerManager.Instance;
        this.playerName.text = playerManager.GetPlayerName(this.playerNumber);

        switch (playerManager.GetPlayerType(this.playerNumber))
        {
            case PlayerManager.PlayerType.JUMPER:
                this.activeAbility = this.jumperAbility;
                this.jumperAbility.gameObject.SetActive(true);
                this.jumperControls.gameObject.SetActive(true);
                this.jumperImage.gameObject.SetActive(true);
                break;
            case PlayerManager.PlayerType.BOMBER:
                this.activeAbility = this.bomberAbility;
                this.bomberAbility.gameObject.SetActive(true);
                this.bomberControls.gameObject.SetActive(true);
                this.bomberImage.gameObject.SetActive(true);
                break;
            case PlayerManager.PlayerType.SHOOTER:
                this.activeAbility = this.shooterAbility;
                this.shooterAbility.gameObject.SetActive(true);
                this.shooterControls.gameObject.SetActive(true);
                this.shooterImage.gameObject.SetActive(true);
                break;
        }

        this.canvasGroup.alpha = 0;
    }

    private void Update()
    {
        float abilityAlpha = this.player.abilityEnabled ? HUD.ABILITY_ENABLED_ALPHA : HUD.ABILITY_DISABLED_ALPHA;

        Color alpha = this.activeAbility.color;
        alpha.a = abilityAlpha;
        this.activeAbility.color = alpha;
    }

}
