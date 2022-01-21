using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables Concerning States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMovementState MovementState { get; private set; }
    public PlayerWalkingBackwards BackwardsMoveState { get; private set; }

    [SerializeField]
    private PlayerData _playerData;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public CapsuleCollider2D CapsuleCollider { get; private set; }

    #endregion

    #region Variables
    [SerializeField] private bool _debugGizmos = false;

    #endregion

    #region Built In Method
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, _playerData, "Idle");
        MovementState = new PlayerMovementState(this, StateMachine, _playerData, "Run");
        BackwardsMoveState = new PlayerWalkingBackwards(this, StateMachine, _playerData, "Backwards");


    }

    private void Start()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
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

    #region Player Methods
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
