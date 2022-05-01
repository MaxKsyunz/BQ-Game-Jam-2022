using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollisionWithPlayer : MonoBehaviour
{
    public GameObject emptyTree;
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
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
            levelManager.fruitCount -= 1;
        }
    }
}
