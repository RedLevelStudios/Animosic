using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    protected int xInput;
    protected int yInput;
    protected Vector2 storedDirection;
    protected Vector2 input;
    protected Vector2 direction;

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

        input = new Vector2(xInput, yInput);
        input.Normalize();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
