using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollisionWithPlayer : MonoBehaviour
{
    public GameObject emptyTree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Instantiate(emptyTree, transform.position, Quaternion.identity);
        }
    }
}
