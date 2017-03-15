using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {
    
    public CharacterSelector player1Selector;
    public CharacterSelector player2Selector;

    private void Awake()
    {
        PlayerManager.Instantiate(2);
        PointSystem.Instantiate(2);
    }

    private void Update()
    {
        if (this.player1Selector.HasSelected && this.player2Selector.HasSelected)
            SceneManager.LoadSceneAsync("character-name");        
    }
}
