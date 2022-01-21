using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    private bool _isFlipping;

    //FacingDirection
    public PlayerIdleState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();
        _isFlipping = player.InputHandler.FlipInput;


        if (!isExistingState)
        {
            if(direction != Vector2.zero && !_isFlipping)
            {
                stateMachine.ChangeState(player.MovementState);
            }else if(direction != Vector2.zero && _isFlipping)
            {
                stateMachine.ChangeState(player.BackwardsMoveState);
            }
        }
    }
}
