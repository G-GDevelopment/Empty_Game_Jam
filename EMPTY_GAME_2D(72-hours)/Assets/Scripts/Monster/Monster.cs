using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, ISpotted
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
    private bool _isSpottedByPlayer;
    private bool _isSpottedByLight;

    public bool IsSpotted { get => _isSpottedByPlayer; set => _isSpottedByPlayer = value; }
    public bool IsSpottedByLight { get => _isSpottedByLight; set => _isSpottedByLight = value; }

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
    public void IsSpottedByPlayer(bool isSpotted)
    {
        Debug.Log("Sweeping Angle Has been spotted");

        _isSpottedByPlayer = isSpotted;

    }
    public void Damage(float amount)
    {
        if(amount > 69)
        {
            Debug.Log("Monster died");

            //Destroy(gameObject, 0.0f);
            gameObject.SetActive(false);

        }
    }
    
    public void LetThereBeLight(bool isLight)
    {
        _isSpottedByLight = isLight;
    }
    public void SetIsSpottedByPlayerToFalse() => _isSpottedByPlayer = false;
    #endregion

    #region DrawGizmos
    private void OnDrawGizmos()
    {
        if (_debugGizmos)
        {
            Gizmos.color = Color.cyan;
            Debug.DrawRay(transform.position, Vector2.right * Core.CollisionSenses.CheckDistance);
            Debug.DrawRay(transform.position, Vector2.left * Core.CollisionSenses.CheckDistance);
            Debug.DrawRay(transform.position, Vector2.up * Core.CollisionSenses.CheckDistance);
            Debug.DrawRay(transform.position, Vector2.down * Core.CollisionSenses.CheckDistance);

            Gizmos.color = Color.red;
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset1, Core.CollisionSenses.OverlapSize);
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset2, Core.CollisionSenses.OverlapSize);
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset3, Core.CollisionSenses.OverlapSize);
            Gizmos.DrawCube(Core.CollisionSenses.CheckPosition.position + (Vector3)Core.CollisionSenses.Offset4, Core.CollisionSenses.OverlapSize);
        }
    }







    #endregion
}
