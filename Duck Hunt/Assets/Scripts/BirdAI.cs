using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bird;
    //public Rigidbody2D rb;
    Vector2 direction;

    Rigidbody2D rb;
    public float x = UnityEngine.Random.Range(1f, 2f);
    public float z = UnityEngine.Random.Range(1f, 2f);
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
        }
    }
}

