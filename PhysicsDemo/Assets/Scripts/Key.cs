using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Entity
{
    public float RotationSpeed = 30f;
    void Update()
    {
        transform.eulerAngles += new Vector3(0f, RotationSpeed * Time.deltaTime, 0f);
    }
}
