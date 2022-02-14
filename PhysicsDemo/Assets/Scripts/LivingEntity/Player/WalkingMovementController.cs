using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMovementController : MonoBehaviour, MovementController
{
    [SerializeField] private CharacterController _character;
    private void Awake()
    {
        _character = gameObject.GetComponent<CharacterController>();
    }
    public void Translate(Vector3 position)
    {
        _character.Move(position);
    }
}
