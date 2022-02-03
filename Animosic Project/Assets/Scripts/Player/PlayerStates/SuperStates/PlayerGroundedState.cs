using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;
    protected Vector2 movementInput;
    protected bool dashInput;


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

        //Debug.Log("Enter Grounded State");
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
        movementInput = player.InputHandler.MovementInput;
        dashInput = player.InputHandler.DashInput;

        if(player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {     
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if(player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }

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

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
