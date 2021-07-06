using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // [Header("Necessary Inputs")]
    // public Transform position;

    private Transform target;
    private int waypoint_index = 0;

    [Header("Parameters")]
    public int speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_direction = (target.position - transform.position).normalized;
        transform.Translate(current_direction*Time.deltaTime*speed, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.1f){
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint(){
        if (waypoint_index >= Waypoints.points.Length-1){
            Destroy(gameObject);
            return;
        }
        waypoint_index++;
        
    }
}
