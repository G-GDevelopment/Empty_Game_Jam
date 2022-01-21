using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState 
{
    protected Core core;

    protected Monster monster;
    protected MonsterStateMachine stateMachine;
    protected PlayerData monsterData;

    protected bool isAnimationFinished;
    protected bool isExistingState;

    protected float startTime;

    private string _animBoolName;

    public MonsterState(Monster p_monster, MonsterStateMachine p_stateMachine, PlayerData p_monsterData, string p_animboolName)
    {
        monster = p_monster;
        stateMachine = p_stateMachine;
        monsterData = p_monsterData;
        _animBoolName = p_animboolName;
        core = monster.Core;

    }

    public virtual void EnterState()
    {
        ChecksForSwitchingState();
        monster.Animator.SetBool(_animBoolName, true);
        startTime = Time.time;
        Debug.Log(_animBoolName);

        isAnimationFinished = false;
        isExistingState = false;
    }

    public virtual void ExitState()
    {
        monster.Animator.SetBool(_animBoolName, false);
        isExistingState = true;
    }

    public virtual void StandardUpdate() { }

    public virtual void FixedUpdate()
    {
        ChecksForSwitchingState();
    }

    public virtual void ChecksForSwitchingState() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishedTrigger() => isAnimationFinished = true;
}
