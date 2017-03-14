using System;
using UnityEngine;
using UnityEngine.UI;

public class TestCharacterSelector : MonoBehaviour {

    public int playerNumber;

    public TestCharacterSelectorPreview playerPreview;
    public TestCharacterSelectorBottomRow bottomRow;
    public TestCharacterSelectorConfirm selectConfirmation;
    
    private bool hasSelected;
    public bool HasSelected
    {
        get { return this.hasSelected; }
    }
    
    private void Start()
    {
        this.SetPlayerType(PlayerManager.PlayerType.BOMBER);
    }

    private void Update()
    {
        
        if (Input.GetButtonDown("Horizontal" + this.playerNumber))
        {
            float horizontal = Input.GetAxis("Horizontal" + this.playerNumber);
            this.PlayerTypeNotSelected();

            PlayerManager.PlayerType currentType = PlayerManager.Instance.GetPlayerType(this.playerNumber);
            currentType += (int)Mathf.Sign(horizontal);
            
            if (currentType < PlayerManager.PlayerType.JUMPER)
                currentType = PlayerManager.PlayerType.SHOOTER;
            else if (currentType > PlayerManager.PlayerType.SHOOTER)
                currentType = PlayerManager.PlayerType.JUMPER;

            this.SetPlayerType(currentType);
        }
        else if (Input.GetButtonDown("Jump" + this.playerNumber))
            this.PlayerTypeSelected();
    }

    private void SetPlayerType(PlayerManager.PlayerType type)
    {
        PlayerManager.Instance.SetPlayerType(this.playerNumber, type);
        this.playerPreview.SetPlayerType(type);
        this.bottomRow.SetPlayerType(type);
    }

    private void PlayerTypeSelected()
    {
        this.hasSelected = true;
        this.selectConfirmation.PlayerTypeSelected(PlayerManager.Instance.GetPlayerType(this.playerNumber));
    }
    
    private void PlayerTypeNotSelected()
    {
        this.hasSelected = false;
        this.selectConfirmation.PlayerTypeNotSelected();
    }
}
