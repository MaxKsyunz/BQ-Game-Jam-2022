using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    public float MovementSpeed = 1;
    public Vector3 moveAmount;

    public float BorderX = 5.0f;
    public float BorderY = 5.0f;

    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(1, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        moveAmount += new Vector3(direction.x *Time.deltaTime * MovementSpeed, direction.y * Time.deltaTime * MovementSpeed, 0);
        Vector3 moveDiff = moveAmount * Time.deltaTime * 8;
        transform.position += moveDiff;
        moveAmount -= moveDiff;

        if (transform.position.x > BorderX)
            transform.position = new Vector3(-BorderY, transform.position.y);

        if (transform.position.x < -BorderX)
            transform.position = new Vector3(BorderX, transform.position.y);

        if (transform.position.y > BorderY)
            transform.position = new Vector3(transform.position.x, -BorderY);

        if (transform.position.y < -BorderY)
            transform.position = new Vector3(transform.position.x, BorderY);
    }
}
