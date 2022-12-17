using UnityEngine;

public class Flying : Enemy
{
    public Transform flowing;
    public float offset = 0.5f;
    public float force = 2;
    private Rigidbody2D rb;
    private Vector2 startPoint;

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
