using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravitySystem : MonoBehaviour, GravitySystem
{
    public void Gravitate(CharacterController gravitatingObject)
    {
        if (!gravitatingObject.isGrounded)
        {
            gravitatingObject.Move(new Vector3(0f, -10f * Time.deltaTime, 0f));
        }
    }
}
