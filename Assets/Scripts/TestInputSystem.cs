//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.InputSystem;

////[RequireComponent(typeof(Rigidbody))]
//public class TestInputSystem : MonoBehaviour
//{
//    private Rigidbody _rigidbody;
//    private BaseActions _playerInputActions;
    
//    public static UnityEvent TeleportTriggered = new UnityEvent();
    
//    private void Awake()
//    {
//        //_rigidbody = transform.GetComponent<Rigidbody>();

//        //var input = GetComponent<PlayerInput>();
//        //input.onActionTriggered += OnActionTriggered;
//        //input.actions["Jump"].performed += Jump;
        
//        _playerInputActions = new BaseActions();
//        _playerInputActions.Player.Enable();
        
//        //_playerInputActions.Player.Jump.performed += Jump;
//        _playerInputActions.Player.Look.performed += Look;
//        //_playerInputActions.Player.Movement.performed += Movement;
//        _playerInputActions.Player.Fire.performed += context => TeleportTriggered.Invoke();
//    }

//    private void Look(InputAction.CallbackContext obj)
//    {
//        Debug.Log($"Look: {obj}");
//    }

//    private void FixedUpdate()
//    {
//        //var inputVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
//        //_rigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y), ForceMode.Force);
//        var lookVector = _playerInputActions.Player.Look.ReadValue<Vector2>();
//        transform.Rotate(new Vector3(0, lookVector.x, 0));
//        Camera.main.transform.Rotate(new Vector3(-lookVector.y, 0, 0));
//    }

//    private void Movement(InputAction.CallbackContext context)
//    {
//        Debug.Log(context);
//        var inputVector = context.ReadValue<Vector2>();
//        _rigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y), ForceMode.Force);
//    }

//    private void OnActionTriggered(InputAction.CallbackContext obj)
//    {
//        if (obj.action.name == "Jump")
//        {
//            Jump(obj);
//        }
//    }

//    public void Jump(InputAction.CallbackContext context)
//    {
//        Debug.Log(context);
//        if (context.performed)
//        {
//            Debug.Log("Jump");
//            _rigidbody.AddForce(Vector3.up, ForceMode.Impulse); //(0,1,0)
//        }
//    }
//}
