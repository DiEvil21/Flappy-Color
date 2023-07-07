using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;



public class PlayerInGameControl : MonoBehaviour
{
    public GameObject circleSprite;
    private Color color;
    private int colorI;
    public Text scoreLabel;
    private int score;
    public GameObject explose;
    public GameObject restartMenu;
    public GameObject bestScoreLabel;
    public int best_score;

    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;


    private void Awake()
    {
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled == true)
        {
            // Если запустился, то запускаем Ваш метод
            GetData();

            // Если плагин еще не прогрузился, то метод не запуститься в методе Start,
            // но он запустится при вызове события GetDataEvent, после прогрузки плагина
        }
    }
    void Start()
    {
        colorI = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChange"))
        {
            ChangeColor(collision.transform.gameObject.GetComponent<ChangeColorMovement>().getColor());
            Debug.Log("ColorChange");
        }
        else if (collision.gameObject.CompareTag("red") && colorI == 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            score++;
            scoreLabel.text = "" + score;
        }
        else if (collision.gameObject.CompareTag("blue") && colorI == 1)
        {
            gameObject.GetComponent<AudioSource>().Play();
            score++;
            scoreLabel.text = "" + score;
        }
        else if (collision.gameObject.CompareTag("green") && colorI == 2)
        {
            gameObject.GetComponent<AudioSource>().Play();
            score++;
            scoreLabel.text = "" + score;
        }
        else 
        {
            circleSprite.GetComponent<SpriteRenderer>().enabled = false;
            restartMenu.GetComponent<restartGameMenu>().startTimer();
            circleSprite.GetComponent<AudioSource>().Play();
            GameObject go = Instantiate(explose, transform.position, Quaternion.identity);
            go.transform.position = gameObject.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GetComponent<CircleCollider2D>().enabled = false;
            if (best_score < score) 
            {
                best_score = score;
                YandexGame.savesData.money = best_score;
                bestScoreLabel.GetComponent<Text>().text =":" + best_score.ToString();
                YandexGame.SaveProgress();
            }
        }
    }

    private void ChangeColor(int colorId) 
    {
        colorI = colorId;
        switch (colorId)
        {
            case 0:
                if (ColorUtility.TryParseHtmlString("#D1382E", out color))
                { circleSprite.GetComponent<SpriteRenderer>().color = color; }
                break;
            case 1:
                if (ColorUtility.TryParseHtmlString("#1ADBD5", out color))
                { circleSprite.GetComponent<SpriteRenderer>().color = color; }
                break;
            case 2:
                if (ColorUtility.TryParseHtmlString("#59E23D", out color))
                { circleSprite.GetComponent<SpriteRenderer>().color = color; }
                break;
        }
    }

    private void GetData() 
    {
        best_score = YandexGame.savesData.money;
        Debug.Log(YandexGame.savesData.money);
        bestScoreLabel.GetComponent<Text>().text = ":" + best_score.ToString();
        
    }
}
