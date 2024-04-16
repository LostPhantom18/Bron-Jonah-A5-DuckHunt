using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bird;
    Vector2 direction;
    Rigidbody2D rb;
    public float speed;
    private Camera camera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
        camera = Camera.main;
    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse Click Detected");
        GameController.score += 10;
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

