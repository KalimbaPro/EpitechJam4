using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nosferapti : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public LayerMask wallMask;
    public float minDistanceToPlayer = 1f;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float avoidRange = 1f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = (player.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, avoidRange, wallMask);

        if (hit.collider != null)
        {
            direction = Vector2.Perpendicular(hit.normal).normalized;
        }

        if (Vector2.Distance(transform.position, player.position) < minDistanceToPlayer)
        {
            direction = GetDirectionAwayFromPlayer();
        }

        rb.velocity = direction * speed;
    }

    private Vector2 GetDirectionAwayFromPlayer()
    {
        float angle = Random.Range(0f, 360f);
        return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<stats>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Bubble"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("malosse") || collision.gameObject.CompareTag("nosferapti"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}




