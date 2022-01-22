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

        if (SetIndex() == 1)
        {
            core.Ability.UpdateBoxCollider(_isThereLight ? playerData.BoxColliderSizeRight + new Vector2(core.CollisionSenses.DistanceFromPlayerToLight * 2.5f, 0) : playerData.BoxColliderSizeRight, _isThereLight ? playerData.BoxColliderOffsetRight * 2 : playerData.BoxColliderOffsetRight);
        }
        else if (SetIndex() == 2)
        {
            core.Ability.UpdateBoxCollider(_isThereLight ? playerData.BoxColliderSizeRight + new Vector2(core.CollisionSenses.DistanceFromPlayerToLight * 2.5f, 0) : playerData.BoxColliderSizeRight, _isThereLight ? playerData.BoxColliderOffsetRight * -2 : playerData.BoxColliderOffsetRight * -1);
        }
        else if (SetIndex() == 3)
        {
            core.Ability.UpdateBoxCollider(_isThereLight ? playerData.BoxColliderSizeUp + new Vector2(0, core.CollisionSenses.DistanceFromPlayerToLight * 2.5f) : playerData.BoxColliderSizeUp, _isThereLight ? playerData.BoxColliderOffsetUp * 2 : playerData.BoxColliderOffsetUp);
        }
        else if (SetIndex() == 4)
        {
            core.Ability.UpdateBoxCollider(_isThereLight ? playerData.BoxColliderSizeUp + new Vector2(0, core.CollisionSenses.DistanceFromPlayerToLight * 2.5f) : playerData.BoxColliderSizeUp, _isThereLight ? playerData.BoxColliderOffsetUp * -2 : playerData.BoxColliderOffsetUp * -1);
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
