using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) // checks if we touch the active waypoint
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) // if object touch the last waypoint, start over again from 0
            {
                currentWaypointIndex = 0;
              
            }

            if (sprite != null)
            {
                sprite.flipX = !sprite.flipX; // flip sprite when it touches a waypoint
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); // move object against waypoint
    }
}
