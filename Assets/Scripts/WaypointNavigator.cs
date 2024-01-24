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
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) // kollar om vi rör vid aktiv waypoint
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) // om vi rör sista waypointen, börja om igen från 0
            {
                currentWaypointIndex = 0;
              
            }

            if (sprite != null)
            {
                sprite.flipX = !sprite.flipX;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); // rör objektet mot waypointen
    }
}
