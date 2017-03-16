using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterName : MonoBehaviour {

    private static readonly string PLAYER_1_DEFAULT_NAME = "Player 1";
    private static readonly string PLAYER_2_DEFAULT_NAME = "Player 2";

    public InputField player1NameField;
    public InputField player2NameField;

    private void Awake()
    {
        PlayerManager playerManager = PlayerManager.Instance;

        playerManager.SetPlayerName(1, CharacterName.PLAYER_1_DEFAULT_NAME);
        playerManager.SetPlayerName(2, CharacterName.PLAYER_2_DEFAULT_NAME);
    }

    private void Start()
    {
        this.player1NameField.text = CharacterName.PLAYER_1_DEFAULT_NAME;
        this.player2NameField.text = CharacterName.PLAYER_2_DEFAULT_NAME;
    }

    public void SetPlayer1Name(string name)
    {
        this.SetPlayerName(1, name);
    }

    public void SetPlayer2Name(string name)
    {
        this.SetPlayerName(2, name);
    }

    private void SetPlayerName(int player, string name)
    {
        if (string.IsNullOrEmpty(name))
            return;

        string trimmedName = name.Trim();
        if (trimmedName.Length == 0)
            return;

        PlayerManager.Instance.SetPlayerName(player, trimmedName);
    }

    public void OnStartClick()
    {
        // TODO: create an actual tutorial
        SceneManager.LoadSceneAsync("level-tutorial");
        //SceneManager.LoadSceneAsync("level-1");
    }
}
