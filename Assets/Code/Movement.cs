using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 1;
    private float scale;
    private Rigidbody2D rigidbody2D;
    void Start()
    {
        scale = transform.localScale.x;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move left if button A is pressed
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            transform.localScale = new Vector2(-scale, scale);
        }
        // Move right if button D is pressed
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
            transform.localScale = new Vector2(scale, scale);
        }
        

    }
}
