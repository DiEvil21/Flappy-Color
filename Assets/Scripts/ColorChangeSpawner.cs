using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeSpawner : MonoBehaviour
{
    public float timeRemaining = 7;
    public bool timerIsRunning = false;
    public GameObject colorChanger;

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
                Instantiate(colorChanger, gameObject.transform.position, Quaternion.identity);
                timeRemaining = 7;
                timerIsRunning = true;
            }
        }
    }


}
