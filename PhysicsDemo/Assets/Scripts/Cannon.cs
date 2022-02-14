using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cannon : Entity
{
    public float ShotInterval = 2f;
    private float shotTime = 0f;
    public GameObject FirePoint;

    public static event Action Fire;

    void Update()
    {
        shotTime += Time.deltaTime;
        if(shotTime >= ShotInterval)
        {
            Fire?.Invoke();
            Game.CannonballPool.GetCannonball(FirePoint.transform.position, transform.eulerAngles.y, 500, 3);
            shotTime = 0f;
        }
    }
}
