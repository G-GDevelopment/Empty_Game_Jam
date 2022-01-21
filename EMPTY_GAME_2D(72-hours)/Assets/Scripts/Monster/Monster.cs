using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    #region Variables Concerning States
    public MonsterStateMachine StateMachine { get; private set; }
    public MonsterIdleState IdleState { get; private set; }
    public MonsterMovementState MovementState { get; private set; }


    [SerializeField]
    private PlayerData _monsterData;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Animator { get; private set; }
    public CapsuleCollider2D CapsuleCollider { get; private set; }

    #endregion

    #region Variables
    [SerializeField] private bool _debugGizmos = false;

    #endregion

    #region Built In Method
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new MonsterStateMachine();

        IdleState = new MonsterIdleState(this, StateMachine, _monsterData, "Idle");
        MovementState = new MonsterMovementState(this, StateMachine, _monsterData, "Run");


    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
        StateMachine.Initialize(IdleState);

    }

    private void Update()
    {
        Core.LogicUpdate();

        StateMachine.CurrentState.StandardUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdate();
    }

    #endregion

    #region Monster Methods
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishedTrigger() => StateMachine.CurrentState.AnimationFinishedTrigger();


    #endregion

    #region DrawGizmos
    private void OnDrawGizmos()
    {
        if (_debugGizmos)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset1, Core.CollisionSenses.OverlapSize);
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset2, Core.CollisionSenses.OverlapSize);
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset3, Core.CollisionSenses.OverlapSize);
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset4, Core.CollisionSenses.OverlapSize);
        }
    }

    #endregion
}
