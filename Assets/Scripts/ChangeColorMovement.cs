using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float SPEED;
    public float multiplier;
    private Color color;
    public int colorId;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        colorId = Random.Range(0, 3);
        switch (colorId)
        {
            case 0:
                if (ColorUtility.TryParseHtmlString("#D1382E", out color))
                { gameObject.GetComponent<SpriteRenderer>().color = color; }
                break;
            case 1:
                if (ColorUtility.TryParseHtmlString("#1ADBD5", out color))
                { gameObject.GetComponent<SpriteRenderer>().color = color; }
                break;
            case 2:
                if (ColorUtility.TryParseHtmlString("#59E23D", out color))
                { gameObject.GetComponent<SpriteRenderer>().color = color; }
                break;
        }
    }

        // Update is called once per frame
        void Update()
        {
            SPEED *= multiplier;
            var direction = new Vector3(-1, 0, 0);
            rb.velocity = direction * SPEED;

            if (rb.position.x < -12)
            {
                Destroy(gameObject);
            }
        }

        public int getColor() 
        {
            return colorId;
        }
    
}
