using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    float boundary = 5 - 0.125f - 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.Translate(moveSpeed * Time.deltaTime * transform.up);
        }

        else if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.Translate(-1 * moveSpeed * Time.deltaTime * transform.up);
        }

        ClampPosition();
    }

    private void ClampPosition()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.y = Mathf.Clamp(clampedPos.y, -boundary, boundary);
        transform.position = clampedPos;
    }

}
