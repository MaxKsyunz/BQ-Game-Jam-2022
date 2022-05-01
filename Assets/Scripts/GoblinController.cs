using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Mood
{
    Casual,
    Hungry,
    Angry
}

[RequireComponent(typeof (SpriteRenderer))]
public class GoblinController : MonoBehaviour
{
    // Level specific waypoint list.
    // Don't forget to for every level in the editor!
    public List<GameObject> defaultWaypoints;
    public List<Sprite> goblinSprites = new List<Sprite>();

    public float speed;
    public const float  patrolSpeed = 2f;
    LinkedList<GameObject> curPath;
    public float sightRadius = 5f;

    SpriteRenderer spriteRenderer;

    GameObject currentTarget;

    Mood goblinMood = Mood.Casual;

    void Start()
    {
        speed = patrolSpeed;
        curPath = new LinkedList<GameObject>();
        loadDefaultPath();
        currentTarget = curPath.First.Value;
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        spriteRenderer.flipX = (currentTarget.transform.position.x > transform.position.x) ? true : false;

        if (transform.position == currentTarget.transform.position)
        {
            curPath.RemoveFirst();
            if (curPath.Count == 0)
            {
                loadDefaultPath();
            }

            currentTarget = curPath.First.Value;
        }

        spriteRenderer.sprite = goblinSprites[(int) goblinMood];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            curPath.AddFirst(collision.gameObject);
            currentTarget = curPath.First.Value;

            goblinMood = Mood.Hungry;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }
}
