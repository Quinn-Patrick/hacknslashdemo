using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableCamera : MonoBehaviour, ICamera
{
    public MonoBehaviour target;
    public float _distance = 6f;
    public float _maxDistance = 6f;
    public float _phi;
    public float _theta;
    public bool mouseControl = true;

    public float _targetTheta = 30f;
    public float _deltaTheta = 30f;

    public Controller control;
    public LayerMask mask;

    void Start()
    {
        _targetTheta = _theta;
    }


    void Update()
    {
        //Avoid issues related to phi equaling zero.
        if(_phi == 0)
        {
            _phi = 0.01f;
        }
        
        SetPosition();
        SetRotation();
        AlterTheta();
        //moveCamera();

        ManageDistance();        
    }

    /// <summary>
    /// Places the camera in 3 dimensional space using spherical coordinates.
    /// </summary>
    void SetPosition()
    {
        float z = _distance * Mathf.Sin(Mathf.Deg2Rad * _theta) * Mathf.Cos(Mathf.Deg2Rad * _phi);
        float x = _distance * Mathf.Sin(Mathf.Deg2Rad * _theta) * Mathf.Sin(Mathf.Deg2Rad * _phi);
        float y = _distance * Mathf.Cos(Mathf.Deg2Rad * _theta);

        gameObject.transform.position = target.gameObject.transform.position + new Vector3(x, y, z);
    }
    /// <summary>
    /// Orients the camera in 3 dimensional space so that it faces the target.
    /// </summary>
    void SetRotation()
    {
        gameObject.transform.LookAt(target.transform);
    }

    private void AlterTheta()
    {
        if(Mathf.Abs(_targetTheta-_theta) > _deltaTheta * Time.deltaTime)
        {
            _theta += _deltaTheta * Time.deltaTime * Mathf.Sign(_targetTheta - _theta);
        }
    }
    

    void ManageDistance()
    {        
        TightenCamera();        
    }

    /// <summary>
    /// Moves the camera closer to the player when there is geometry in between the camera and the player.
    /// </summary>
    bool TightenCamera()
    {
        float trueDistance = _distance;
        bool hasTightened = false;
        Vector3 direction;

        direction = (gameObject.transform.position - target.GetComponent<CharacterController>().transform.position).normalized;
        while (Physics.Raycast(gameObject.transform.position - (direction*(trueDistance-_distance)), direction, _distance, mask) && _distance > 0.2f)
        {
            _distance -= 0.02f;
            hasTightened = true;
        }

        while (!Physics.Raycast(gameObject.transform.position - (direction * (trueDistance - _distance)), direction, _distance, mask) && _distance < _maxDistance)
        {
            _distance += 0.02f;
        }

        return hasTightened;
    }

    public void SetTheta(float theta)
    {
        _theta = theta;
    }

    public void SetPhi(float phi)
    {
        _phi = phi;
    }

    public void SetTargetTheta(float theta)
    {
        _targetTheta = theta;
    }

    
}
