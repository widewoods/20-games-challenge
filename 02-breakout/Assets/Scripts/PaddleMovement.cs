using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera cam;

    [Header("Variables")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;

    float currentSpeed;

    float boundary;
    const float WALL_WIDTH = 0.5f;

    void Start()
    {
        float worldHeight = cam.orthographicSize * 2;
        float worldWidth = worldHeight * cam.aspect;
        boundary = worldWidth / 2 - (transform.localScale.x / 2 + WALL_WIDTH);
    }

    void Update()
    {
        Accelerate();
        MovePaddle();
        ClampPosition();
    }

    void MovePaddle()
    {
        transform.Translate(currentSpeed * Time.deltaTime * transform.right);
    }

    void Accelerate()
    {
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }

        else if (Keyboard.current.leftArrowKey.isPressed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, -maxSpeed, acceleration * Time.deltaTime);
        }

        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);
        }
    }

    private void ClampPosition()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -boundary, boundary);
        transform.position = clampedPos;
    }
}
