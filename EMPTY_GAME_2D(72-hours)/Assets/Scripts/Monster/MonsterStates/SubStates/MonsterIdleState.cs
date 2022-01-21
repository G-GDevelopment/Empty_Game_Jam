using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdleState : MonsterGroundedState
{
    public MonsterIdleState(Monster p_monster, MonsterStateMachine p_stateMachine, PlayerData p_monsterData, string p_animboolName) : base(p_monster, p_stateMachine, p_monsterData, p_animboolName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        core.Movement.SetMovementZero();
        direction = Vector2.zero;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();


        if (!isExistingState)
        {
            if (direction != Vector2.zero)
            {
                stateMachine.ChangeState(monster.MovementState);
            }

        }
    }
}
