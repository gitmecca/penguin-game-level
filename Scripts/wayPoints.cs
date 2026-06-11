using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//orginal script by: Stephen on youtube at https://www.youtube.com/watch?v=GIDz0DjhA4E


// Enemy Waypoint Patrol Script

// Moves an enemy/object between waypoints in a loop.

public class wayPoints : MonoBehaviour

{

    [Header("Player Reference")]

    public GameObject player;

    [Header("Waypoint Settings")]

    public List<Transform> waypoints = new List<Transform>();

    public float minDistance = 0.1f;

    public bool loopWaypoints = true;

    [Header("Movement Settings")]

    public float movementSpeed = 5.0f;

    public float rotationSpeed = 5.0f;

    [Header("Debug Settings")]

    public bool showDebugRays = true;

    private Transform targetWaypoint;

    private int targetWaypointIndex = 0;

    private int lastWaypointIndex;

    private void Start()

    {

        if (waypoints.Count == 0)

        {

            Debug.LogWarning("No waypoints assigned to " + gameObject.name);

            enabled = false;

            return;

        }

        lastWaypointIndex = waypoints.Count - 1;

        targetWaypoint = waypoints[targetWaypointIndex];

    }

    private void Update()

    {

        if (targetWaypoint == null)

        {

            return;

        }

        MoveToWaypoint();

    }

    private void MoveToWaypoint()

    {

        float movementStep = movementSpeed * Time.deltaTime;

        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;

        if (directionToTarget != Vector3.zero)

        {

            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        }

        if (showDebugRays)

        {

            Debug.DrawRay(transform.position, transform.forward * 50f, Color.green);

            Debug.DrawRay(transform.position, directionToTarget, Color.red);

        }

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        if (distance <= minDistance)

        {

            GoToNextWaypoint();

        }

        transform.position = Vector3.MoveTowards(

            transform.position,

            targetWaypoint.position,

            movementStep

        );

    }

    private void GoToNextWaypoint()

    {

        targetWaypointIndex++;

        if (targetWaypointIndex > lastWaypointIndex)

        {

            if (loopWaypoints)

            {

                targetWaypointIndex = 0;

            }

            else

            {

                enabled = false;

                return;

            }

        }

        targetWaypoint = waypoints[targetWaypointIndex];

    }

}