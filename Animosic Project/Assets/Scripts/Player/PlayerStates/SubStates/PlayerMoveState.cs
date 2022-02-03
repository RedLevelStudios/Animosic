using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private int movementDelay;
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        movementDelay = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        movementDelay++;

        if (movementInput != Vector2.zero && movementDelay > playerData.movementDelayTime)
        {
            player.SetVelocity(movementInput * playerData.movementVelocity);
            player.SetDirection(movementInput);
            //player.SetAnimDirection(movementInput);
            movementDelay = 0;
        }

        if (movementInput == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
            movementDelay = 0;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
