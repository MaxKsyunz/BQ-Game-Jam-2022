using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public float speed = 3f;
    public Transform[] waypoints;
    bool loop = true;
    //float pauseDuration = 0;

    float curTime;
    int currentWaypoint = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            Patrol();
        }
        else
        {
            if (loop)
            {
                currentWaypoint = 0;
            }
        }
    }

    void Patrol()
    {

        Vector3 target = waypoints[currentWaypoint].position;
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (transform.position == target)
        {
            currentWaypoint++;
        }
    }


}
