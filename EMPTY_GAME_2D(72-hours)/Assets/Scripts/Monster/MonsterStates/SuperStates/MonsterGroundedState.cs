using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGroundedState : MonsterState
{
    protected int inputX;
    protected int inputY;
    protected Vector2 direction;
    public MonsterGroundedState(Monster p_monster, MonsterStateMachine p_stateMachine, PlayerData p_monsterData, string p_animboolName) : base(p_monster, p_stateMachine, p_monsterData, p_animboolName)
    {
    }

    public override void StandardUpdate()
    {
        base.StandardUpdate();

        SetDirection();

        inputX = Mathf.RoundToInt(direction.x);
        inputY = Mathf.RoundToInt(direction.y);
    }

    private void SetDirection()
    {
        if (core.CollisionSenses.RightRaycast)
        {
            direction = Vector2.right;
        }else if (core.CollisionSenses.LeftRaycast)
        {
            direction = Vector2.left;
        }else if (core.CollisionSenses.UpRaycast)
        {
            direction = Vector2.up;
        }else if (core.CollisionSenses.DownRaycast)
        {
            direction = Vector2.down;
        }
    }
}
