using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGameMenu : MonoBehaviour
{
    public float timeRemaining = 1;
    public bool timerIsRunning = false;
    public GameObject restartMenu;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = false;
    }
    public void startTimer() 
    {
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
                restartMenu.SetActive(true);
                Time.timeScale = 0;
               
                timerIsRunning = false;
            }
        }
    }


}
