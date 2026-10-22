using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    struct AABB
    {
        public Vector2 min;
        public Vector2 max;
    }

    [SerializeField] private float baseMoveSpeed;
    private float moveSpeed;
    private Vector2 velocity;
    [SerializeField] private Transform topWall;
    [SerializeField] private Transform bottomWall;
    [SerializeField] private Transform leftPaddle;
    [SerializeField] private Transform rightPaddle;

    // For collision
    private float topWallMinY;
    private float bottomWallMaxY;

    void Start()
    {
        moveSpeed = baseMoveSpeed;
        velocity = Vector2.one.normalized;
        topWallMinY = topWall.position.y - topWall.localScale.y / 2;
        bottomWallMaxY = bottomWall.position.y + bottomWall.localScale.y / 2;
        GameManager.OnBallRespawn += ResetSpeed;
    }

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * velocity);

        CheckWallCollision();
        CheckPaddleCollision();
    }

    void OnDestroy()
    {
        GameManager.OnBallRespawn -= ResetSpeed;
    }

    void ResetSpeed()
    {
        moveSpeed = baseMoveSpeed;
    }

    void CheckWallCollision()
    {
        float ballTop = transform.position.y + transform.localScale.y / 2;
        float ballBottom = transform.position.y - transform.localScale.y / 2;
        //Check collision with top wall
        if (ballTop > topWallMinY)
        {
            Vector3 clampedPos = transform.position;
            clampedPos.y = topWallMinY - transform.localScale.y / 2;
            transform.position = clampedPos;

            velocity.y = -velocity.y;
        }

        //Check collision with bottom wall
        if (ballBottom < bottomWallMaxY)
        {
            Vector3 clampedPos = transform.position;
            clampedPos.y = bottomWallMaxY + transform.localScale.y / 2;
            transform.position = clampedPos;

            velocity.y = -velocity.y;
        }
    }

    void CheckPaddleCollision()
    {
        AABB ballAABB = CalculateAABB(transform);

        AABB leftPaddleAABB = CalculateAABB(leftPaddle);
        AABB rightPaddleAABB = CalculateAABB(rightPaddle);

        //Check collision with left paddle
        if (CheckAABBCollision(ballAABB, leftPaddleAABB))
        {
            Vector2 MTV = GetAABB_MTV(ballAABB, leftPaddleAABB);


            float reflect = Mathf.Clamp((transform.position.y - leftPaddle.position.y) / (leftPaddle.localScale.y / 2), -1f, 1f);
            Vector2 reflectVelocity = new Vector2(1f, reflect);

            transform.position = (Vector2)transform.position + MTV;

            velocity = reflectVelocity.normalized;

            moveSpeed += 0.5f;
        }

        //Check collision with right paddle
        if (CheckAABBCollision(ballAABB, rightPaddleAABB))
        {
            Vector2 MTV = GetAABB_MTV(ballAABB, rightPaddleAABB);


            float reflect = Mathf.Clamp((transform.position.y - rightPaddle.position.y) / (rightPaddle.localScale.y / 2), -1f, 1f);
            Vector2 reflectVelocity = new Vector2(-1f, reflect);

            transform.position = (Vector2)transform.position + MTV;

            velocity = reflectVelocity.normalized;

            moveSpeed += 0.5f;
        }
    }

    bool CheckAABBCollision(AABB a, AABB b)
    {
        bool xColliding = a.max.x > b.min.x && a.min.x < b.max.x;
        bool yColliding = a.max.y > b.min.y && a.min.y < b.max.y;
        return xColliding && yColliding;
    }

    Vector2 GetAABB_MTV(AABB a, AABB b)
    {
        float overlapX1 = a.max.x - b.min.x;
        float overlapX2 = b.max.x - a.min.x;
        float overlapX = Mathf.Min(overlapX1, overlapX2);

        float overlapY1 = a.max.y - b.min.y;
        float overlapY2 = b.max.y - a.min.y;
        float overlapY = Mathf.Min(overlapY1, overlapY2);

        float aCenterX = (a.max.x + a.min.x) / 2;
        float aCenterY = (a.max.y + a.min.y) / 2;
        float bCenterX = (b.max.x + b.min.x) / 2;
        float bCenterY = (b.max.y + b.min.y) / 2;

        if (overlapX < overlapY) // Collide in x axis
        {
            float sign = (aCenterX < bCenterX) ? -1.0f : 1.0f;
            return new Vector2(overlapX * sign, 0);
        }
        else
        {
            float sign = (aCenterY < bCenterY) ? -1.0f : 1.0f;
            return new Vector2(0, overlapY * sign);
        }
    }

    AABB CalculateAABB(Transform rectangle)
    {
        AABB aabb;
        float minX = rectangle.position.x - rectangle.localScale.x / 2;
        float minY = rectangle.position.y - rectangle.localScale.y / 2;
        float maxX = rectangle.position.x + rectangle.localScale.x / 2;
        float maxY = rectangle.position.y + rectangle.localScale.y / 2;
        aabb.min = new Vector2(minX, minY);
        aabb.max = new Vector2(maxX, maxY);

        return aabb;
    }
}
