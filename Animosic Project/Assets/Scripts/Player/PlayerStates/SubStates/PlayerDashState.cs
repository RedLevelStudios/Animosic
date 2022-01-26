using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerGroundedState
{

    private float dashStartTime;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        dashStartTime = Time.time + playerData.dashDuration;
        Debug.Log("Enter Dash State");
    }

    public override void Exit()
    {
        base.Exit();
        dashStartTime = 0;
        Debug.Log("Exit Dash State");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Debug.Log("Time: " + Time.time);
        //Debug.Log("Dash Start Time: " + dashStartTime);
        Debug.Log("Dash Velocity Test: " + (player.CurrentDirection * playerData.dashVelocity));
        player.SetDash(player.CurrentDirection * playerData.dashVelocity);

        if(Mathf.RoundToInt(Time.time) == Mathf.RoundToInt(dashStartTime))
        {

            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
