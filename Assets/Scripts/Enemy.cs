using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Allows for AI Functions in Unity
public class Enemy : MonoBehaviour
{

    public NavMeshAgent agent;
    //Public declaration for NavMeshAgent, used to navigate the terrain. Functions will not work if UnityEngine.AI is not mentioned in the system requirements 

    public Transform waypointParent;
    //Public declaration for the Parent waypoint coordinates (Scale, Rotation and Position) that the AI Agent will navigate to.

    public float moveSpeed = 5f;
    //Public float for the moveSpeed of the AI Agent

    public float stoppingDistance = 1f;
    //Public float for the AI agents stopping Distance when within a waypoints area

    private Transform[] waypoints;
    //Private declaration of array. This contain waypoints coordinates (Scale, Rotation and Position) that the AI Agent will travel to after the Parent Waypoint. Cant be referenced outside of this script

    private int currentIndex = 1;
    //Private int for the numerical order used to determine order of waypoints. Current array index is set to 1. Cant be referenced outside of this script

    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //Get the coordinates/transform of the waypoint childrens under the waypoint parent
    }

    void Update()
    {
        Transform point = waypoints[currentIndex];
        //Coordinates of waypoints in array

        float distance = Vector3.Distance(transform.position, point.position);
        //Float distance on xyz axis between waypoints, relative to their scale,rotation and position in the scene

        //AI Agent will move to the next waypoint if the distance between the current waypoint and next waypoint is close enough
        if (distance < 1.5f)
        {
            currentIndex++;
            //Current waypoint in array sequence + 1
        }
        agent.SetDestination(point.position);
        //Sets AI agent destitation on navmesh to point position value

        //If the current index is greater than or equal to the length between waypoints
        if (currentIndex >= waypoints.Length)
        {
            //Moves to next waypoint
            currentIndex = 1;
        }
    }
}