using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int fruitCount;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fruitCount <= 0)
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single); 
        }
    }
}
