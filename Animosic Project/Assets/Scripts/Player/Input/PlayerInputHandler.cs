using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{


    public Vector2 MovementInput{ get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool DashInput { get; private set; }

    public bool SwordInput { get; private set; }

    private float dashInputStartTime;

    private void Update()
    {
        CheckDashInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(MovementInput.x);
        NormInputY = Mathf.RoundToInt(MovementInput.y);
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            dashInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            DashInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + .02f)
        {
            DashInput = false;
        }
    }

    public void OnSwordInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwordInput = true;
        }

        if (context.canceled)
        {
            SwordInput = false;
        }
    }
}
