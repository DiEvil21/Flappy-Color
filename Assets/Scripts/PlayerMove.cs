using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float jumpHeight = 7f;
    public GameObject circle;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody.velocity.y > 0)
        {
            
            if (circle.transform.rotation.z < 0.3f) 
            {
                circle.transform.Rotate(new Vector3(0, 0, 0.5f * 200 * Time.deltaTime));
            }
            
        }
        else 
        {
            
            if (circle.transform.rotation.z > -0.3f) 
            {
                circle.transform.Rotate(new Vector3(0, 0, -0.3f * 200 * Time.deltaTime));
            }
            
        }
    }
    public void Jump() 
    {
        //rigidbody.AddForce(transform.up * 700f);
        var currentVel = rigidbody.velocity;
        var newVel = new Vector3(currentVel.x, jumpHeight, currentVel.y);
        rigidbody.velocity = newVel;
    }
}
