using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IBaseState CurrentState { get; private set; }

    public void Update()
    {
        CurrentState?.Tick();
    }

    public void ChangeState(IBaseState newState)
    {
        CurrentState?.OnStateExit();
        CurrentState = newState;
        CurrentState?.OnStateEnter();
    }
}
