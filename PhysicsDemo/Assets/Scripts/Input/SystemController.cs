using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    public static SystemController Instance;

    Controls _controls;

    private bool _yesPressed;
    private bool _noPressed;
    private float _upDownInput;
    private float _leftRightInput;

    private bool _canPressYes;
    private bool _canPressNo;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _controls = new Controls();

        _controls.SystemControls.Yes.performed += ctx => _yesPressed = true;
        _controls.SystemControls.No.performed += ctx => _noPressed = true;
        _controls.SystemControls.UpDown.performed += ctx => _upDownInput = ctx.ReadValue<float>();
        _controls.SystemControls.LeftRight.performed += ctx => _leftRightInput = ctx.ReadValue<float>();


        _controls.SystemControls.Yes.canceled += ctx => _yesPressed = false;
        _controls.SystemControls.No.canceled += ctx => _noPressed = false;
        _controls.SystemControls.UpDown.canceled += ctx => _upDownInput = 0f;
        _controls.SystemControls.LeftRight.canceled += ctx => _leftRightInput = 0f;
    }
    private void Update()
    {
        if (!_yesPressed) _canPressYes = true;
        if (!_noPressed) _canPressNo = true;

        if (!_canPressYes) _yesPressed = false;
        if (!_canPressNo) _noPressed = false;
    }
    private void OnEnable()
    {
        _controls.SystemControls.Enable();
    }
    public bool YesPressed()
    {
        if (_yesPressed) _canPressYes = false;
        return _yesPressed;
    }
    public bool NoPressed()
    {
        if (_noPressed) _canPressNo = false;
        return _noPressed;
    }
    public float UpDownInput()
    {
        return _upDownInput;
    }
    public float LeftRightInput()
    {
        return _leftRightInput;
    }
}
