using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] float minSpeed = 4f, maxSpeed = 10f;
    private bool moveOnx, moveOnY = true;
    private float speedX, speedY;
    [SerializeField] float minRotationSpeed = 15f, maxRotationSpeed = 500f;
    private float rotationSpeed;
    private Vector3 tempMovement;
    private float zRotation;

    private void Awake()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if(Random.Range(0, 2) > 0) { speedX *= -1f; }
        if(Random.Range(0, 2) > 0) { rotationSpeed *= -1f; }
        if(Random.Range(0, 2) > 0) { moveOnx = true; }
    }
    private void Update()
    {
        HandleMovementX();
        HandleMovementY();
        RotateMeteor();
    }
    private void HandleMovementX()
    {
        if (!moveOnx) { return;}
        tempMovement = transform.position;
        tempMovement.x += speedX * Time.deltaTime;
        transform.position = tempMovement;
    }
    private void HandleMovementY()
    {
        if (!moveOnY) { return; }
        tempMovement = transform.position;
        tempMovement.y -= speedY * Time.deltaTime;
        transform.position = tempMovement;
    }

    private void RotateMeteor()
    {
        zRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }
}
