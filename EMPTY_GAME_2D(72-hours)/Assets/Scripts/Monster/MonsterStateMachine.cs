using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine
{
    public MonsterState CurrentState { get; private set; }
    public void Initialize(MonsterState p_startingState)
    {
        CurrentState = p_startingState;
        CurrentState.EnterState();
    }

    public void ChangeState(MonsterState p_newState)
    {
        CurrentState.ExitState();
        CurrentState = p_newState;
        CurrentState.EnterState();
    }
}
