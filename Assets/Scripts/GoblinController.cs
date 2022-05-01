using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    // Level specific waypoint list.
    // Don't forget to drag and drop in the editor!
    public List<GameObject> defaultWaypoints;

    public float speed;
    public const float  patrolSpeed = 2f;
    LinkedList<GameObject> curPath;
    public float sightRadius = 5f;

    GameObject currentTarget;

    void Start()
    {
        speed = patrolSpeed;
        curPath = new LinkedList<GameObject>();
        loadDefaultPath();
        currentTarget = curPath.First.Value;
    }

    private void loadDefaultPath()
    {
        for (int i = defaultWaypoints.Count - 1; i > 0; i--)
        {
            curPath.AddLast(defaultWaypoints[i]);
        }
    }

    void Update()
    {
        WalkAround();
    }

    void WalkAround()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, step);

        if (transform.position == currentTarget.transform.position)
        {
            curPath.RemoveFirst();
            if (curPath.Count == 0)
            {
                loadDefaultPath();
            }

            currentTarget = curPath.First.Value;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
