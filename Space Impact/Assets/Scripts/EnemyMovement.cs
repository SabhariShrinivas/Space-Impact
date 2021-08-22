using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool moveOnX, moveOnY;
    [SerializeField] private float moveSpeed= 8f;
    [SerializeField] private float horizontalMovementThreshold = 8f;
    [SerializeField] private float verticalMovementThreshold = 8f;
    private Vector3 tempMovementHorizontal;
    private Vector3 tempMovementVertical;
    private bool moveLeft;
    private bool moveUp = false;
    private float minX, minY, maxX, maxY;
    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x - horizontalMovementThreshold;
        maxX = transform.position.x + horizontalMovementThreshold;
        maxY = transform.position.y;
        minY = transform.position.y - verticalMovementThreshold;

        if(Random.Range(0, 2) < 1) { moveLeft = true; }
    }

    // Update is called once per frame
    void Update()
    {
        HandleEnemyMovementHorizontal();
        HandleEnemyMovementVerticle();
    }
    void HandleEnemyMovementHorizontal()
    {
        if (!moveOnX) { return; }
        if (moveLeft)
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if(tempMovementHorizontal.x < minX)
            {
                moveLeft = false;
            }

        }
        else
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x > maxX)
            {
                moveLeft = true;
            }
        }
    }
    void HandleEnemyMovementVerticle()
    {
        if (! moveOnY) { return; }
        if (moveUp)
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;
            
            if(tempMovementVertical.y > maxY)
            {
                moveUp = false;
            }
        }
        else
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;

            if (tempMovementVertical.y < minY)
            {
                moveUp = true;
            }
        }
    }
}
