using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseState
{
    void OnStateEnter();
    void OnStateExit();
    void Tick();
}
