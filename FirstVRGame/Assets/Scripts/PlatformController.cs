using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // destinations
    public Transform[] targets;

    // Speed
    public float speed = 1f;

    // Movement Flag
    bool isMoving = false;

    // Starting position of the player
    public int startingPosition = 0;

    // Next destination
    private int nextIndex;

    // Start is called before the first frame update
    private void Start()
    {
        // set initial position to first target
        transform.position = targets[startingPosition].position;

        // First next target
        nextIndex = ((startingPosition + 1) == targets.Length) ? 0 : (startingPosition + 1);
    }

    // Update is called once per frame
    private void Update()
    {
        // Check for input
        HandleInput();

        if (isMoving)
        {
            // Move to target
            HandleMovement();
        }
    }
    
    private void HandleInput()
    {
        // Get Button down
        isMoving = Input.GetButton("Fire1");
    }

    // take care of movement
    private void HandleMovement()
    {
        // calculate the distance from target
        float distance = Vector3.Distance(transform.position, targets[nextIndex].position);

        // check if haven't arrived
        if (distance > 0)
        {
            // calculate how much to move (step) d = v * t
            float step = speed * Time.deltaTime;

            // move by that step
            transform.position = Vector3.MoveTowards(transform.position, targets[nextIndex].position, step);
        }
        // check if have arrived
        else
        {
            // change to next destination;
            nextIndex = ((nextIndex + 1) == targets.Length) ? 0 : (nextIndex + 1) ;
        }

    }
}
