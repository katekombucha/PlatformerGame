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
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.velocity.y);

        if (rigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector2(-scale, scale);
        }
        else if (rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector2(scale, scale);
        }
    }
}
