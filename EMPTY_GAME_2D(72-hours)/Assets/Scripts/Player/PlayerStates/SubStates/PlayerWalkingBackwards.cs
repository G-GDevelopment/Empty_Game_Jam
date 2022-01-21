using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingBackwards : PlayerGroundedState
{
    private bool _isFlipping;

    public PlayerWalkingBackwards(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }


    public override void EnterState()
    {
        base.EnterState();
        core.Movement.SetMovingBackWardsToTrue();
    }

    public override void ExitState()
    {
        base.ExitState();
        core.Movement.SetMovingBackWardsToFalse();

    }
    public override void StandardUpdate()
    {
        base.StandardUpdate();
        _isFlipping = player.InputHandler.FlipInput;

        core.Movement.SetMovement(direction, inputX, inputY, playerData.MovementSpeedBack);

        if (direction == Vector2.zero && !core.Movement.IsMoving && !_isFlipping)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
