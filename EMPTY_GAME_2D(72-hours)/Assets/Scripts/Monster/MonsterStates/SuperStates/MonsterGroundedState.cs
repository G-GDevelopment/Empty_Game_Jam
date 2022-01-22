using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGroundedState : MonsterState
{
    protected int inputX;
    protected int inputY;
    protected Vector2 direction;
    protected int setIndex;

    private Vector2 _lastSavedDirection;
    public MonsterGroundedState(Monster p_monster, MonsterStateMachine p_stateMachine, PlayerData p_monsterData, string p_animboolName) : base(p_monster, p_stateMachine, p_monsterData, p_animboolName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        core.Ability.SetIsThisMonsterToTrue();
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();

        SetDirection();
        core.CollisionSenses.SetTrueOffsetValue(setIndex);

        inputX = Mathf.RoundToInt(direction.x);
        inputY = Mathf.RoundToInt(direction.y);

        if (monster.IsSpotted)
        {
            if(!core.CollisionSenses.IsPlayerLeavingLookingZone(_lastSavedDirection))
            {
                monster.SetIsSpottedByPlayerToFalse();
            }
        }
    }

    private void SetDirection()
    {
        if (!monster.IsSpotted)
        {
            if (core.CollisionSenses.RightRaycast)
            {
                direction = Vector2.right;
                _lastSavedDirection = direction;
                setIndex = 1;
            }else if (core.CollisionSenses.LeftRaycast)
            {
                direction = Vector2.left;
                _lastSavedDirection = direction;
                setIndex = 2;
            }else if (core.CollisionSenses.UpRaycast)
            {
                direction = Vector2.up;
                _lastSavedDirection = direction;
                setIndex = 3;
            }else if (core.CollisionSenses.DownRaycast)
            {
                direction = Vector2.down;
                _lastSavedDirection = direction;
                setIndex = 4;
            }
        }
        else
        {
            direction = Vector2.zero;
        }
    }

}
