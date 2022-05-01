using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float MovementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        
        transform.position += new Vector3(horizontal * Time.deltaTime * MovementSpeed, vertical * Time.deltaTime * MovementSpeed, 0);
    }
}
