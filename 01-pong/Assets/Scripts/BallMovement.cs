using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 velocity;
    [SerializeField] private Transform topWall;
    [SerializeField] private Transform bottomWall;
    [SerializeField] private Transform leftPaddle;
    [SerializeField] private Transform rightPaddle;


    // For collision
    private Vector2 topWallMin;
    private Vector2 topWallMax;
    private Vector2 bottomWallMin;
    private Vector2 bottomWallMax;
    private Vector2 ballMin;
    private Vector2 ballMax;

    void Start()
    {
        velocity = Vector2.one.normalized;
        Vector2[] topWallRect = CalculateRectPos(topWall);
        Vector2[] bottomWallRect = CalculateRectPos(bottomWall);

        topWallMin = topWallRect[0];
        topWallMax = topWallRect[1];
        bottomWallMin = bottomWallRect[0];
        bottomWallMax = bottomWallRect[1];
    }

    void FixedUpdate()
    {
        transform.Translate(moveSpeed * Time.fixedDeltaTime * velocity);

        CheckWallCollision();
        CheckPaddleCollision();
    }

    void CheckWallCollision()
    {
        Vector2[] ballRect = CalculateRectPos(transform);
        ballMin = ballRect[0];
        ballMax = ballRect[1];

        //Check collision with top wall
        if (AABB(ballMin, ballMax, topWallMin, topWallMax))
        {
            Vector3 clampedPos = transform.position;
            clampedPos.y = topWallMin.y - transform.localScale.y / 2;
            transform.position = clampedPos;

            velocity.y = -velocity.y;
        }

        //Check collision with bottom wall
        if (AABB(ballMin, ballMax, bottomWallMin, bottomWallMax))
        {
            Vector3 clampedPos = transform.position;
            clampedPos.y = bottomWallMax.y + transform.localScale.y / 2;
            transform.position = clampedPos;

            velocity.y = -velocity.y;
        }
    }

    void CheckPaddleCollision()
    {
        Vector2[] ballRect = CalculateRectPos(transform);
        ballMin = ballRect[0];
        ballMax = ballRect[1];

        Vector2[] leftPaddleRect = CalculateRectPos(leftPaddle);
        Vector2[] rightPaddleRect = CalculateRectPos(rightPaddle);

        //Check collision with left paddle
        if (AABB(ballMin, ballMax, leftPaddleRect[0], leftPaddleRect[1]))
        {
            Vector3 clampedPos = transform.position;
            clampedPos.x = leftPaddleRect[1].x + transform.localScale.x / 2;
            transform.position = clampedPos;

            velocity.x = -velocity.x;
        }

        //Check collision with right paddle
        if (AABB(ballMin, ballMax, rightPaddleRect[0], rightPaddleRect[1]))
        {
            Vector3 clampedPos = transform.position;
            clampedPos.x = rightPaddleRect[0].x - transform.localScale.x / 2;
            transform.position = clampedPos;

            velocity.x = -velocity.x;
        }
    }

    bool AABB(Vector2 AMin, Vector2 AMax, Vector2 BMin, Vector2 BMax)
    {
        bool xColliding = AMax.x > BMin.x && AMin.x < BMax.x;
        bool yColliding = AMax.y > BMin.y && AMin.y < BMax.y;
        return xColliding && yColliding;
    }

    Vector2[] CalculateRectPos(Transform rectangle)
    {
        float minX = rectangle.position.x - rectangle.localScale.x / 2;
        float minY = rectangle.position.y - rectangle.localScale.y / 2;
        float maxX = rectangle.position.x + rectangle.localScale.x / 2;
        float maxY = rectangle.position.y + rectangle.localScale.y / 2;

        return new Vector2[] { new(minX, minY), new(maxX, maxY) };
    }
}
