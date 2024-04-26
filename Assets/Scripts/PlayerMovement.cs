using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private bool isDragging = false;

    public float speed = 12f;
    public Camera _camera;

    public CharacterController characterController;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistanse = 0.4f; // Радиус сферы для проверки приземления игрока

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        if (_camera == null)
        {
            // Если камера не назначена в инспекторе, используем главную камеру
            _camera = Camera.main;
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistanse);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        if (isDragging)
        {
            // Определяем вектор движения в направлении, куда направлена камера
            Vector3 forward = _camera.transform.forward;
            forward.y = 0; // Исключаем движение по вертикали
            forward.Normalize(); // Нормализуем вектор, чтобы его длина была равна 1

            Vector3 moveDirection = _camera.transform.forward * speed * Time.deltaTime;


            // Начало движения
            characterController.Move(moveDirection + velocity * Time.deltaTime);

        }

    }


    public void Go(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            isDragging = true;
        }
        else if (callbackContext.phase == InputActionPhase.Canceled)
        {
            isDragging = false;
        }

    }

}
