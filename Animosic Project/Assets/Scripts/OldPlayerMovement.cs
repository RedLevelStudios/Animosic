using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState1
{
    Walk,
    Attacking,
    Dash,
    Interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState1 currentState;

    private Rigidbody2D myRigidbody;
    private Vector3 movementChange;
    private Animator movementAnim;
    public Vector3 currentDirection = new Vector3(0, -1, 0);
    public float playerSpeed;
    public float dashSpeed = 35;
    public float dashCount = 5;
    public float swordDashSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState1.Walk;
        movementAnim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        movementAnim.SetFloat("moveX", 0);
        movementAnim.SetFloat("moveY", -1); ;
    }

    // Update is called once per frame
    void Update()
    {
        movementChange = Vector3.zero;
        movementChange.x = Input.GetAxisRaw("Horizontal");
        movementChange.y = Input.GetAxisRaw("Vertical");
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("dash") && dashCount <= 1 && currentState != PlayerState1.Dash)
        {

            StartCoroutine(DashCo());
        }

        else if (currentState == PlayerState1.Walk)
        {
            if (Input.GetButtonDown("dash") && dashCount <= 1 && currentState != PlayerState1.Dash)
            {
                StartCoroutine(DashCo());
            }
            UpdateAnimationAndMove();
        }

        if (Input.GetButtonDown("sword1") && currentState != PlayerState1.Attacking)
        {
            StartCoroutine(Sword1Co());
        }

        if (Input.GetButtonDown("Mouse X") && currentState != PlayerState1.Attacking)
        {
            movementAnim.SetFloat("moveX", worldPosition.x);
            movementAnim.SetFloat("moveY", worldPosition.y);
            StartCoroutine(Sword1Co());
        }

        //Debug.Log(dashCount);
        //Debug.Log(currentState);
        Debug.Log(worldPosition);
    }

    private IEnumerator DashCo()
    {
        DashCharacter();
        StartCoroutine(DashCountCo());
        yield return new WaitForSeconds(.10f);
        movementAnim.SetBool("dashing", false);
        myRigidbody.velocity = Vector3.zero;
        currentState = PlayerState1.Walk;
    }

    private IEnumerator Sword1Co()
    {
        movementAnim.SetBool("sword1", true);
        if (movementAnim.GetBool("moving"))
        {
            myRigidbody.AddForce(currentDirection * swordDashSpeed, ForceMode2D.Impulse);
        }
        currentState = PlayerState1.Attacking;
        yield return null;
        movementAnim.SetBool("sword1", false);
        yield return new WaitForSeconds(.25f);
        myRigidbody.velocity = Vector3.zero;
        yield return new WaitForSeconds(.04f);
        currentState = PlayerState1.Walk;
    }

    void UpdateAnimationAndMove()
    {
        if (movementChange != Vector3.zero)
        {
            MoveCharacter();
            movementAnim.SetFloat("moveX", movementChange.x);
            movementAnim.SetFloat("moveY", movementChange.y);
            movementAnim.SetBool("moving", true);
        }

        else
        {
            movementAnim.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        movementChange.Normalize();
        myRigidbody.MovePosition(transform.position + movementChange * playerSpeed * Time.fixedDeltaTime);
        currentDirection = movementChange;
    }

    void DashCharacter()
    {
        dashCount += 1;
        movementAnim.SetBool("dashing", true);
        currentState = PlayerState1.Dash;
        currentDirection.Normalize();
        myRigidbody.AddForce(currentDirection * dashSpeed, ForceMode2D.Impulse);
    }

    private IEnumerator DashCountCo()
    {
        yield return new WaitForSeconds(1);
        dashCount -= 1;
    }
}
