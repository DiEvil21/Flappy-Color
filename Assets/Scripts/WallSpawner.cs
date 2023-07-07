using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public float timeRemaining = 3;
    public bool timerIsRunning = false;
    public GameObject wall;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                
            }
            else
            {
                Debug.Log("Time has run out!");
                Instantiate(wall, gameObject.transform.position, Quaternion.identity);
                timeRemaining = 3;
                timerIsRunning = true;
            }
        }
    }

    
}
