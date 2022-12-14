using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementControls : MonoBehaviour
{
    public Rigidbody snakeHead;
    private Camera mainCamera;

    private Vector3 lastInpitPos;
    private float sidewaysSpeed;

    public int speed;
    public float sensitivity;

    void Start()
    {
        snakeHead = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastInpitPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = mainCamera.ScreenToViewportPoint(Input.mousePosition) - lastInpitPos;
            sidewaysSpeed += delta.x * sensitivity;
            lastInpitPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        snakeHead.velocity = new Vector3(sidewaysSpeed * sensitivity, 0, speed);
    }
}
