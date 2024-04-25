using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation;


    public void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation += mouseX;
        xRotation = Mathf.Clamp(-90f, xRotation, 90f);

        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseY);

    }

}
