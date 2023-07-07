using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject restartMenu;
    public GameObject score;
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playGame() 
    {
        Time.timeScale = 1;
        restartMenu.SetActive(false);
        score.SetActive(true);
    }
    public void restartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
