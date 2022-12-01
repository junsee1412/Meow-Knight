using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : Enemy
{
    public Transform flowing;
    public float offset = 0.5f;
    public float force = 2;
    Rigidbody2D rb;
    Vector2 startPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPoint = rb.transform.position;
    }
    void Update()
    {
        // rb.velocity = new Vector2(rb.position, startPoint, moveSpeed);
    }
}
