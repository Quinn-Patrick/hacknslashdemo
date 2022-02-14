using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : Controller
{
    public Boss self;
    private void Awake()
    {
        moveForward = 0;
        moveSideways = 0;
        sprintHeld = false;
        attacking = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        moveForward = Mathf.Sin(Mathf.Deg2Rad * self._targetAngle);
        moveSideways = Mathf.Cos(Mathf.Deg2Rad * self._targetAngle);
    }

    private void OnEnable(){}
}
