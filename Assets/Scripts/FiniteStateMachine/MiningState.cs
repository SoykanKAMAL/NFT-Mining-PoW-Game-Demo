using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningState : IBaseState
{
    private float _miningPercentage => timer / miningTime * 100;
    private float timer = 0;
    private float miningTime => Gamemanager.Instance.MiningTime / Gamemanager.Instance.MineSpeed;
    public void OnStateEnter()
    {
        UiManager.Instance.SetCurrentStateText("<color=green>MINING");
    }

    public void OnStateExit()
    {
        UiManager.Instance.SetUpdateMessageText($"<color=green>MINED {Gamemanager.Instance.BaseMiningReward * Gamemanager.Instance.MineReward} COINS", 4000);
    }

    public void Tick()
    {
        timer += Time.deltaTime;
        UiManager.Instance.SetMiningPercentageText(_miningPercentage.ToString("F0") + "%");
        if (timer >= miningTime)
        {
            Gamemanager.OnMineFinished?.Invoke();
            Gamemanager.OnStateChanged(new IdleState());
        }
    }
}
