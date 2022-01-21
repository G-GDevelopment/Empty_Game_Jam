using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }

    public int NormalizeInputX { get; private set; }
    public int NormalizeInputY { get; private set; }
    public bool FlipInput { get; private set; }

    public void Update()
    {

    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormalizeInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormalizeInputY = Mathf.RoundToInt(RawMovementInput.y);

    }

    public void OnFlipInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FlipInput = true;
        }

        if (context.canceled)
        {
            FlipInput = false;
        }
    }


}
