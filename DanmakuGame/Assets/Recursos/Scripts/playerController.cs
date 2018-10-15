using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed = 3f;
    public float maxSpeed = 3f;
    float limitedSpeed;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);

        if (Mathf.Abs(h) < speed)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        float v = Input.GetAxis("Vertical");
        rb2d.AddForce(Vector2.up * speed * v);

        if (Mathf.Abs(v) < speed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }

        limitedSpeed = Mathf.Clamp(rb2d.velocity.y, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(rb2d.velocity.x, limitedSpeed);

    }
}
