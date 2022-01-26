using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Components

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }

    #endregion

    #region Other Variables
    public Vector2 CurrentDirection { get; private set; }
    private Vector2 workspace;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);

        if(CurrentDirection == Vector2.zero)
        {
            CurrentDirection = new Vector2(0, -1);
        }
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        //Debug.Log(StateMachine.CurrentState);
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Set Functions
    public void SetVelocity(Vector2 velocity)
    {
        workspace.Set(velocity.x, velocity.y);
        RB.velocity = workspace;
        workspace.Normalize();
    }

    public void SetDirection(Vector2 direction)
    {
        CurrentDirection = direction;
    }

    public void SetAnimDirection(Vector2 animDirection)
    {
        Anim.SetFloat("dirX", animDirection.x);
        Anim.SetFloat("dirY", animDirection.y);
        //Debug.Log(animDirection);
    }

    #endregion

    #region Check Functions
    #endregion

    #region Other Functions
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    #endregion

}