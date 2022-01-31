using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{

    private float sleepTimer;
    private bool canSleep;
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(Vector2.zero);
        player.SetAnimDirection(player.CurrentDirection);

        sleepTimer = Time.time + playerData.sleepTime;
        canSleep = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (movementInput != Vector2.zero)
        {
            player.Anim.SetBool("sleep", false);
            stateMachine.ChangeState(player.MoveState);
        }

        if (sleepTimer <= Time.time && canSleep)
        {
            player.Anim.SetBool("sleep", true);
            canSleep = false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
