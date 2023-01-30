using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ERC1155BalanceOf : MonoBehaviour
{
    public string tokenId;
    public TextMeshProUGUI BalanceText;
    async void OnEnable()
    {
        string chain = "ethereum";
        string network = "goerli";
        string contract = "0xf4910C763eD4e47A585E2D34baA9A4b611aE448C";
        string account = Gamemanager.Instance.WalletAddress;

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        
        if(balanceOf <= 0)
        {
            this.gameObject.SetActive(false);
        }
        
        BalanceText.text = "x" + balanceOf.ToString();
    }

    public void SelectTool()
    {
        Gamemanager.Instance.SelectTool(tokenId);
    }
}
