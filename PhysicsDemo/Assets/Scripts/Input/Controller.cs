using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    Controls playerControls;

    protected float moveForward;
    protected float moveSideways;
    protected bool sprintHeld;
    protected bool attacking;

    private void Awake()
    {
        playerControls = new Controls();

        playerControls.MainControls.ForwardBackwardMovement.performed += ctx => moveForward = ctx.ReadValue<float>();
        playerControls.MainControls.LeftRightMovement.performed += ctx => moveSideways = ctx.ReadValue<float>();
        playerControls.MainControls.Sprint.performed += ctx => sprintHeld = true;
        playerControls.MainControls.Attack.performed += ctx => attacking = true;

        playerControls.MainControls.ForwardBackwardMovement.canceled += ctx => moveForward = 0f;
        playerControls.MainControls.LeftRightMovement.canceled += ctx => moveSideways = 0f;
        playerControls.MainControls.Sprint.canceled += ctx => sprintHeld = false;
        playerControls.MainControls.Attack.canceled += ctx => attacking = false;
    }

    private void OnEnable()
    {
        playerControls.MainControls.Enable();
    }

    public float getForwardMovement()
    {
        
        return moveForward;
    }
    public float getSidewaysMovement()
    {
        return moveSideways;
    }

    public bool getSprint()
    {
        return sprintHeld;
    }

    public bool getAttack()
    {
        return attacking;
    }
}
