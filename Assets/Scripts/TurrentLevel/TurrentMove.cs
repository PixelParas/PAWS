using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class TurrentMove : MonoBehaviour
{
    public Transform target;
    public Transform pointA; // Starting point
    public Transform pointB; // Ending point
    public float speed = 2f; // Speed of movement
    public float rotationSpeed = 2f; // Speed of movement
    public float pauseDuration = 2f; // Pause duration after hit

    private Transform targetPoint; // Current target point
    private bool isPaused = false;

    public bool isHitable = true;


    void Start()
    {
        targetPoint = pointA;
    }

    void Update()
    {
        if (!isPaused)
        {
            if (target.transform.rotation.z < 0.0f)
                target.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            // Move towards the target point
            target.transform.position = Vector3.MoveTowards(target.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, targetPoint.position.z), speed * Time.deltaTime);

            // Check if we have reached the target point
            if (Math.Abs(target.transform.position.z - targetPoint.position.z) < 0.01f)
            {
                if (targetPoint == pointA)
                    targetPoint = pointB;
                else
                    targetPoint = pointA;
            }
        }
        else
        {
            if(target.transform.rotation.z > -76.0f)
                target.transform.eulerAngles = new Vector3(0f, 0f, -76f);
        }
    }

    public void Hit()
    {
        if (!isPaused && isHitable)
        {
            StartCoroutine(PauseMovement());
        }
    }

    private IEnumerator PauseMovement()
    {
        isPaused = true;
        isHitable = false;
        yield return new WaitForSeconds(pauseDuration);
        isPaused = false;
        yield return new WaitForSeconds(1.0f);
        isHitable = true;
    }
}