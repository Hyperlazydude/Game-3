using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorConfirm : MonoBehaviour {

    public Text selectedMessage;
    public GameObject notSelectedMessage;

    private void Start()
    {
        this.PlayerTypeNotSelected();
    }

    public void PlayerTypeSelected(PlayerManager.PlayerType playerType)
    {
        this.selectedMessage.text = playerType.ToString() + " selected!";

        this.notSelectedMessage.SetActive(false);
        this.selectedMessage.gameObject.SetActive(true);
    }

    public void PlayerTypeNotSelected()
    {
        this.selectedMessage.gameObject.SetActive(false);
        this.notSelectedMessage.SetActive(true);
    }
}
