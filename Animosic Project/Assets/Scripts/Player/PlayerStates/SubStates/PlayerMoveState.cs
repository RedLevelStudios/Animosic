using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
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
    }

    public override void Exit()
    {
        base.Exit();

        //Debug.Log("Move Exit Input: " + input);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocity(playerData.movementVelocity * input);
        player.SetAnimDirection(input);

        if (input != Vector2.zero)
        {
            player.SetDirection(input);
        }

        else if (input == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
