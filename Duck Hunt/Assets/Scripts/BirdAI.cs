using System.Collections;
using System.Collections.Generic;

//using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class BirdAI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bird;
    public Rigidbody2D rigidbody2d;
    public Rigidbody2D rb;
    public BoxCollider2D boxcollider2d;
    public Transform transform;
    public SpriteRenderer spriteRenderer;
    private bool isHit = false;
    Vector2 direction;
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
        
        if (isHit == false)
        {
            Leaderboard.levelScore += 10;
            Leaderboard.killedBirds += 1;
            boxcollider2d.enabled = false;
            spriteRenderer.color = Color.gray;
            transform.Rotate(0f, 0f, 45f, Space.Self);
            rigidbody2d.gravityScale = 1;
        }
        isHit = true;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isHit == false)
        {
            rb.velocity = direction * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isHit == false)
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
}

