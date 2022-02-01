using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Animator baseAnimator;
    protected Animator weaponAnimator;
    protected PlayerAttackState state;
    protected int attackCounter;

    protected virtual void Start()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= 3)
        {
            attackCounter = 0;
        }

        SetAnimationDirection(state.CurrentDirection);

        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

        //baseAnimator.SetInteger("attackCounter", attackCounter);
        //weaponAnimator.SetInteger("attackCounter", attackCounter);

        Debug.Log("Attack Counter: " + attackCounter);
    }

    public virtual void ExitWeapon()
    {
        Debug.Log("Trying to exit weapon.");
        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    #region Animation Triggers

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.state = state;
    }

    private void SetAnimationDirection(Vector2 direction)
    {
        direction.Normalize();
        baseAnimator.SetFloat("animX", direction.x);
        baseAnimator.SetFloat("animY", direction.y);
        weaponAnimator.SetFloat("animX", direction.x);
        weaponAnimator.SetFloat("animY", direction.y);
    }
}
