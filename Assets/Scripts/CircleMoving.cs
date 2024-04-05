using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoving : MonoBehaviour
{
    public GameObject character;
    public Transform center;
    float newRotationY = 0;
    float newTransformX = 0.01f;
    float newTransformZ = 0.01f;
    [SerializeField]
    float rotarion = 1, radius = 2, speed = 0;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        character.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, newRotationY, 0), Time.deltaTime * 5);
        newRotationY = (transform.rotation.eulerAngles.y - rotarion) % 360;
        //character.transform.position += new Vector3(newTransformX, 0, newTransformZ);
        newTransformX = center.position.x + Mathf.Cos(angle) * radius;
        newTransformZ = center.position.z + Mathf.Sin(angle) * radius;
        transform.position = new Vector3(newTransformX, character.transform.position.y, newTransformZ);
        angle = angle + Time.deltaTime * speed;
        if (angle >= 360)
        {
            angle = 0;
        }
    }
}
