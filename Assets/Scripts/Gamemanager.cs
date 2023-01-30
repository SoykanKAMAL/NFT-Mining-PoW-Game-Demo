using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[DefaultExecutionOrder(-100)]
public class Gamemanager : Singleton<Gamemanager>
{
    public static Action OnStartMiningRequested;
    public static Action OnMineFinished;
    public static Action<IBaseState> OnStateChanged;
    public static Action<ToolType> OnToolChanged;

    private string _walletAddress;
    
    public float MiningTime = 20f;
    public int BaseMiningReward = 25;
    public int CurrentCoins = 0;
    public int MineSpeed = 0;
    public int MineReward = 0;
    public ToolType CurrentTool = ToolType.WoodenPickaxe;
    public enum ToolType
    {
        WoodenPickaxe,
        IronPickaxe,
        GoldPickaxe,
        DiamondPickaxe
    }
    
    public string WalletAddress
    {
        get
        {
            if (_walletAddress == null)
            {
                _walletAddress = PlayerPrefs.GetString("Account");
            }
            return _walletAddress;
        }
    }
    
    private StateMachine _stateMachine;
    
    private void Start()
    {
        OnStateChanged += OnStateChangedMethod;
        OnMineFinished += () => CurrentCoins += BaseMiningReward * MineReward;
        
        _stateMachine = new StateMachine();
        _stateMachine.ChangeState(new IdleState());
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void OnStateChangedMethod(IBaseState state)
    {
        _stateMachine.ChangeState(state);
    }

    public void SelectTool(string nftID)
    {
        switch (nftID)
        {
            case "28152971085080777056991832242702682132069313006632435761559378916265018004360":
                CurrentTool = ToolType.WoodenPickaxe;
                MineSpeed = 2;
                MineReward = 1;
                break;
            case "28152971085080777056991832242702682132069313006632435761559378912966483117032":
                CurrentTool = ToolType.IronPickaxe;
                MineSpeed = 2;
                MineReward = 3;
                break;
            case "28152971085080777056991832242702682132069313006632435761559378914065994744808":
                CurrentTool = ToolType.GoldPickaxe;
                MineSpeed = 1;
                MineReward = 5;
                break;
            case "28152971085080777056991832242702682132069313006632435761559378915165506371684":
                CurrentTool = ToolType.DiamondPickaxe;
                MineSpeed = 4;
                MineReward = 4;
                break;
        }
        
        OnToolChanged?.Invoke(CurrentTool);
    }
}
