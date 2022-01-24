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

        if (lastInputX == 1 && lastInputY == 0)
        {
            if (!core.Movement.IsWalkingBackwards)
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeRight, playerData.BoxColliderOffsetRight);
            }
            else
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeRight, playerData.BoxColliderOffsetRight * -1);

            }

        }
        
        if (lastInputX == -1 && lastInputY == 0)
        {
            if (!core.Movement.IsWalkingBackwards)
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeRight, playerData.BoxColliderOffsetRight * -1);
            }
            else
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeRight, playerData.BoxColliderOffsetRight);
            }
        }

        if (lastInputY == 1 && lastInputX == 0)
        {
            if (!core.Movement.IsWalkingBackwards)
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeUp, playerData.BoxColliderOffsetUp);
            }
            else
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeUp, playerData.BoxColliderOffsetUp * -1);
            }
        }
        
        if (lastInputY == -1 && lastInputX == 0)
        {
            if (!core.Movement.IsWalkingBackwards)
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeUp, playerData.BoxColliderOffsetUp * -1);
            }
            else
            {
                core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeUp, playerData.BoxColliderOffsetUp);
            }
        }


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
