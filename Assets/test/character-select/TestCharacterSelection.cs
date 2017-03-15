using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCharacterSelection : MonoBehaviour {
    
    public TestCharacterSelector player1Selector;
    public TestCharacterSelector player2Selector;

    private void Awake()
    {
        PlayerManager.Instantiate(2);
        PointSystem.Instantiate(2);
    }

    private void Update()
    {
        if (this.player1Selector.HasSelected && this.player2Selector.HasSelected)
            SceneManager.LoadSceneAsync("test-character-name");        
    }
}
