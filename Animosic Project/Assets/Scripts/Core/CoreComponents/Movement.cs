using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{

    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    public Vector2 CurrentDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();
        Anim = GetComponentInParent<Animator>();
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }

    private Vector2 workspace;
 
    #region Set Functions
    public void SetVelocity(Vector2 velocity)
    {
        workspace.Set(velocity.x, velocity.y);
        RB.velocity = workspace;
    }

    public void SetDirection(Vector2 direction)
    {
        CurrentDirection = direction;
        CurrentDirection.Normalize();
        SetAnimationDirection(direction);
    }

    public void ResetCurrentDirection(Vector2 direction)
    {
        CurrentDirection = direction;
        SetAnimationDirection(direction);
    }

    public void SetAnimationDirection(Vector2 direction)
    {
        Anim.SetFloat("dirX", Mathf.RoundToInt(direction.x));
        Anim.SetFloat("dirY", Mathf.RoundToInt(direction.y));
    }
  #endregion
}
