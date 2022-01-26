using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    protected int xInput;
    protected int yInput;
    protected Vector2 testInput;
    protected Vector2 movementInput;
    protected Vector2 lastDirection;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;

        movementInput = new Vector2(xInput, yInput);
        movementInput.Normalize();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
