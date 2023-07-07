using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float SPEED;
    public float multiplier;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
}
