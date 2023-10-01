using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{

    public GameObject[] waypoints;
    public int CurrentWaypoint =0;


    public float movementSpeed;
    

    
    void Update()
    {
        if(CurrentWaypoint < waypoints.Length)
        {
            Transform target = waypoints[CurrentWaypoint].transform;
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            if(transform.position == target.position)
            {
                CurrentWaypoint ++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
