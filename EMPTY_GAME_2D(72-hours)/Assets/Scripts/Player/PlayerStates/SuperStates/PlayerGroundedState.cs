using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int inputX;
    protected int inputY;

    protected int lastInputX;
    protected int lastInputY;
    protected Vector2 direction;
    protected Vector2 lastDirection;

    protected bool _isThereLight;
    public PlayerGroundedState(Player p_player, PlayerStateMachine p_stateMachine, PlayerData p_playerData, string p_animboolName) : base(p_player, p_stateMachine, p_playerData, p_animboolName)
    {
    }

    public override void ChecksForSwitchingState()
    {
        base.ChecksForSwitchingState();
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (_isThereLight)
        {
            GameEvents.current.TriggerLightTile();

        }
        else
        {
            GameEvents.current.ExitLightTile();
            GameEvents.current.LookingAway();

        }

    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();

        inputX = player.InputHandler.NormalizeInputX;
        inputY = player.InputHandler.NormalizeInputY;
        _isThereLight = core.CollisionSenses.IsPlayerLookingLongdistance(lastDirection);

        player.Animator.SetFloat("InputY", lastInputY);
        player.Animator.SetFloat("InputX", lastInputX);


        core.CollisionSenses.SetTrueOffsetValue(SetIndex());

        direction = new Vector2(inputX, inputY);
        UpdateLastKnownInput(inputX, inputY);

        if (SetIndex() == 1)
        {
            core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeRight, playerData.BoxColliderOffsetRight);
        }
        else if (SetIndex() == 2)
        {
            core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeRight, playerData.BoxColliderOffsetRight * -1);
        }
        else if (SetIndex() == 3)
        {
            core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeUp, playerData.BoxColliderOffsetUp);
        }
        else if (SetIndex() == 4)
        {
            core.Ability.UpdateBoxCollider(playerData.BoxColliderSizeUp, playerData.BoxColliderOffsetUp * -1);
        }

        Debug.DrawRay(player.transform.position, direction * 10, Color.red);
    }

    public int SetIndex()
    {
        if(lastInputX == 1 && lastInputY == 0)
        {
            return core.Movement.IsWalkingBackwards ? 2 : 1;

        }else if(lastInputX == -1 && lastInputY == 0)
        {
            return core.Movement.IsWalkingBackwards ? 1 : 2;

        }else if(lastInputY == 1 && lastInputX == 0)
        {
            return core.Movement.IsWalkingBackwards ? 4 : 3;
        }else if(lastInputY == -1 && lastInputX == 0)
        {
            return core.Movement.IsWalkingBackwards ? 3 : 4;
        }

        return 4;
    }

    private void UpdateLastKnownInput(int p_x, int p_y)
    {
        if(p_x != 0 && p_y == 0)
        {
            lastInputX = p_x;
            lastInputY = 0;
        }

        if(p_y != 0 && p_x == 0)
        {
            lastInputY = p_y;
            lastInputX = 0;
        }

        lastDirection = new Vector2(lastInputX, lastInputY);
    }
}
