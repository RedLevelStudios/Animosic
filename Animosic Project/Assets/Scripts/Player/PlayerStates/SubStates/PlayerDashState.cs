using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerGroundedState
{
    private float dashStopTime;
    private int dashAmountLeft;
    private float dashAmountTime;
    public float dashResetTime;


    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        dashAmountLeft = playerData.dashAmount;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        dashStopTime = Time.time + playerData.dashDuration;
        dashAmountTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time < dashStopTime && CanDash())
        {
            player.SetDash(player.CurrentDirection * playerData.dashVelocity);
            player.SetAnimDirection(player.CurrentDirection);
        }
        else
        {
            DecreaseDashAmount();
            player.SetDash(Vector2.zero);
            dashResetTime = Time.time + playerData.dashCooldown;
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool CanDash()
    {
        if (dashAmountLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    } 

    public void ResetDashAmount() => dashAmountLeft = playerData.dashAmount;
    public void DecreaseDashAmount() => dashAmountLeft--;

}
