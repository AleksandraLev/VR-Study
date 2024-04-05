using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    #region Mouse variables

    public enum RotetionAxes
    {
        MouseXAndY = 0,
        MouseY = 1,
        MouseX = 2,
    }
    public RotetionAxes axes = RotetionAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    private float minimumVert = -30;
    private float maximumVert = 40;
    private float mimimumHor = -20;
    private float maximumHor = 20;
    private float _rotationX = 0;
    private float _rotationY = 0;

    #endregion

    //[SerializeField] private Animation animation;
    private bool goForward;
    //public InputAction action;
    // Start is called before the first frame update
    CharacterController characterController;
    public int mouseSensitivity = 1;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (goForward)
        {
            //transform.position += new Vector3(Camera.main.transform.forward.x, y: 0, Camera.main.transform.forward.z) * Time.deltaTime * 3;
            characterController.Move(new Vector3(Camera.main.transform.forward.x, y: 0, Camera.main.transform.forward.z) * Time.deltaTime * 5);
        }
        
        if (axes == RotetionAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationY = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            _rotationY = RestrictAngle(transform.localEulerAngles.y + delta, mimimumHor, maximumHor);
            transform.localEulerAngles = new Vector3(_rotationX * mouseSensitivity, _rotationY, z: 0);
        }
        else if (axes == RotetionAxes.MouseX)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            transform.localEulerAngles = new Vector3(_rotationX * mouseSensitivity, y: 0, z: 0);
        }
        else if (axes == RotetionAxes.MouseY)
        {
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            _rotationY = RestrictAngle(transform.localEulerAngles.y + delta, mimimumHor, maximumHor);
            transform.localEulerAngles = new Vector3(x: 0, _rotationY, z: 0);
        }


    }
    public void Go(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            goForward = true;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled)
        {
            goForward = false;
        }

    }

    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 100)
            angle -= 360;
        else if (angle < -180)
            angle += 360;
        return angle;
    }
}
