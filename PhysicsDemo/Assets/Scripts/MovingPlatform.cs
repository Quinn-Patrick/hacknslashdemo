using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 targetPosition;
    Vector3 startingPosition;
    bool outOrBack = true; //true = out, false = back

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    private void FixedUpdate()
    {
        Vector3 dir = GetDirection();
        Vector3 targetVelocity = dir * speed;



        gameObject.GetComponent<Rigidbody>().AddForce(targetVelocity - gameObject.GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);
        float postDistance = GetDistance();
        if (postDistance < 0.1f)
        {
            outOrBack = !outOrBack;
        }
    }

    

    private Vector3 GetDirection()
    {
        if (outOrBack)
        {
            return (targetPosition - gameObject.GetComponent<Rigidbody>().position).normalized;
        }
        else
        {
            return (startingPosition - gameObject.GetComponent<Rigidbody>().position).normalized;
        }
    }

    private float GetDistance()
    {
        if (outOrBack)
        {
            return (targetPosition - gameObject.GetComponent<Rigidbody>().position).magnitude;
        }
        else
        {
            return (startingPosition - gameObject.GetComponent<Rigidbody>().position).magnitude;
        }
    }
}
