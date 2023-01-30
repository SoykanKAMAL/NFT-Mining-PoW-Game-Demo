using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IBaseState
{
    
    public void OnStateEnter()
    {
        Gamemanager.OnStartMiningRequested += StartMining;
        
        UiManager.Instance.SetCurrentStateText("<color=yellow>IDLE");
    }

    public void OnStateExit()
    {
        UiManager.Instance.SetUpdateMessageText("<color=blue>STARTED MINING!", 2000);
    }

    public void Tick()
    {
    }

    private void StartMining()
    {
        Gamemanager.OnStartMiningRequested -= StartMining;
        Gamemanager.OnStateChanged(new MiningState());
    }
}
