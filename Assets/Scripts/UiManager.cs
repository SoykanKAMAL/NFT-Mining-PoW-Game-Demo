using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class UiManager : Singleton<UiManager>
{
    public TextMeshProUGUI WalletAddressText;
    public TextMeshProUGUI CurrentStateText;
    public TextMeshProUGUI UpdateMessageText;
    public TextMeshProUGUI MiningPercentageText;
    public TextMeshProUGUI CurrentCoinsText;
    
    public GameObject ToolSelectionPanel;
    public TextMeshProUGUI CurrentToolStatsText;
    public Image WoodenPickaxeImage;
    public Image IronPickaxeImage;
    public Image GoldPickaxeImage;
    public Image DiamondPickaxeImage;
    
    public Button StartMiningButton;
    private void SetupUi()
    {
        WalletAddressText.text = $"<color=green>{Gamemanager.Instance.WalletAddress}";
    }
    
    public void SetCurrentStateText(string state)
    {
        CurrentStateText.text = $"Current State: {state}";
    }
    
    public async void SetUpdateMessageText(string message, int delay)
    {
        UpdateMessageText.text = message;
        
        await Task.Delay(delay);
        
        UpdateMessageText.text = "";
    }
    
    public void SetMiningPercentageText(string percentage)
    {
        MiningPercentageText.text = percentage;
    }
    
    private void SetCurrentCoinsText()
    {
        CurrentCoinsText.text = Gamemanager.Instance.CurrentCoins.ToString();
    }
    
    private void Start()
    {
        Gamemanager.OnToolChanged += SelectTool;
        Gamemanager.OnMineFinished += () => SetMiningPercentageText("");
        Gamemanager.OnMineFinished += () => StartMiningButton.interactable = true;
        Gamemanager.OnMineFinished += SetCurrentCoinsText;
        StartMiningButton.onClick.AddListener(() => StartMiningButton.interactable = false);
        StartMiningButton.onClick.AddListener(() => Gamemanager.OnStartMiningRequested?.Invoke());
        SetupUi();
    }
    
    private void SelectTool(Gamemanager.ToolType toolType)
    {
        switch (toolType)
        {
            case Gamemanager.ToolType.WoodenPickaxe:
                WoodenPickaxeImage.gameObject.SetActive(true);
                IronPickaxeImage.gameObject.SetActive(false);
                GoldPickaxeImage.gameObject.SetActive(false);
                DiamondPickaxeImage.gameObject.SetActive(false);
                break;
           case Gamemanager.ToolType.IronPickaxe:
               IronPickaxeImage.gameObject.SetActive(true);
               GoldPickaxeImage.gameObject.SetActive(false);
               WoodenPickaxeImage.gameObject.SetActive(false);
               DiamondPickaxeImage.gameObject.SetActive(false);
               break;
            case Gamemanager.ToolType.GoldPickaxe:
                GoldPickaxeImage.gameObject.SetActive(true);
                IronPickaxeImage.gameObject.SetActive(false);
                WoodenPickaxeImage.gameObject.SetActive(false);
                DiamondPickaxeImage.gameObject.SetActive(false);
                break;
            case Gamemanager.ToolType.DiamondPickaxe:
                DiamondPickaxeImage.gameObject.SetActive(true);
                IronPickaxeImage.gameObject.SetActive(false);
                GoldPickaxeImage.gameObject.SetActive(false);
                WoodenPickaxeImage.gameObject.SetActive(false);
                break;
        }
        
        CurrentToolStatsText.text = $"{toolType}\nMineSpeed: {Gamemanager.Instance.MineSpeed}/5\nMineReward: {Gamemanager.Instance.MineReward}/5";
        ToolSelectionPanel.SetActive(false);
    }
}
