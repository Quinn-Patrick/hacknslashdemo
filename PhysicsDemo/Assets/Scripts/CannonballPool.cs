using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballPool : ObjectPool
{
    public Cannonball BaseObject;
    // Start is called before the first frame update
    void Start()
    {
        Game.CannonballPool = this;
        InitializePool(BaseObject, 20);
    }

    public Cannonball GetCannonball(Vector3 position, float forceAngle, float forceMagnitude, float lifetime)
    {
        Cannonball outBall = (Cannonball)TakeObject();
        forceAngle *= Mathf.Deg2Rad;
        outBall.transform.position = position;
        outBall.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        outBall.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceMagnitude*Mathf.Sin(forceAngle), 0f, forceMagnitude * Mathf.Cos(forceAngle)));
        outBall.Life = lifetime;
        return outBall;
    }

    public void ReturnCannonball(Cannonball obj)
    {
        ReturnObject(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
