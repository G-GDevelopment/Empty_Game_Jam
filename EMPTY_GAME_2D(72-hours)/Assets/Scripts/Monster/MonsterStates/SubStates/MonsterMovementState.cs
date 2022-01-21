using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovementState : MonsterGroundedState
{
    public MonsterMovementState(Monster p_monster, MonsterStateMachine p_stateMachine, PlayerData p_monsterData, string p_animboolName) : base(p_monster, p_stateMachine, p_monsterData, p_animboolName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();

        core.Movement.SetMovement(direction, inputX, inputY, monsterData.MovementSpeed);

        if (direction == Vector2.zero && !core.Movement.IsMoving)
        {
            stateMachine.ChangeState(monster.IdleState);
            //Set FacingDirection before leaving this state to Idle
        }
    }
}
