using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerGroundedState
{
    private bool _isFlipping;
    public PlayerMovementState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        core.PlayerAudio.PickRandomSound("Footstep1", "Footstep2", "Footstep3", "Footstep4");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();
        _isFlipping = player.InputHandler.FlipInput;



        core.Movement.SetMovement(direction, inputX, inputY, playerData.MovementSpeed);

        if (direction == Vector2.zero && !core.Movement.IsMoving)
        {
            stateMachine.ChangeState(player.IdleState);
            //Set FacingDirection before leaving this state to Idle
        }else if(direction  != Vector2.zero && _isFlipping)
        {
            stateMachine.ChangeState(player.BackwardsMoveState);
        }
    }
}
