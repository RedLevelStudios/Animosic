using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;
    protected bool dashInput;
    protected Vector2 movementInput;
    protected bool swordInput;

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
        dashInput = player.InputHandler.DashInput;
        swordInput = player.InputHandler.SwordInput;

        if (Time.time > player.DashState.dashResetTime)
        {
            player.DashState.ResetDashAmount();
        }

        if (dashInput && player.DashState.CanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        else
        {
            movementInput = new Vector2(xInput, yInput);
            movementInput.Normalize();
        }

        if (swordInput)
        {
            player.SetAnimator(player.anim2);
        }
        else
        {
            player.SetAnimator(player.anim1);
            player.SetAnimDirection(player.CurrentDirection);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
