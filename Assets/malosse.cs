using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malosse : MonoBehaviour
{
    public GameObject prefab;
    public int maxPrefabs = 3;
    public int maxLives = 3;
    public float speed = 3f;
    public float minimumDistance = 5f;
    public float changeTime = 2f;
    private int lives;
    private bool isDead = false;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private int currentPrefabs;
    private Vector2 direction;
    private float moveTimer = 0f;
    private bool facingRight = true;

    private void Start()
    {
        lives = maxLives;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        direction = GetRandomDirection();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
        moveTimer += Time.deltaTime;
        
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (facingRight && direction.x < 0 || !facingRight && direction.x > 0)
        {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if (moveTimer >= changeTime)
        {
            direction = GetRandomDirection();
            moveTimer = 0f;
        }

        rb.velocity = direction * speed;

        if (currentPrefabs < maxPrefabs && !fireInDistance())
        {
            SpawnPrefab();
        }
    }

    private Vector2 GetRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        return new Vector2(x, y);
    }

    private bool fireInDistance()
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("fire");

        foreach (GameObject p in prefabs)
        {
            if (Vector2.Distance(transform.position, p.transform.position) < minimumDistance)
            {
                return true;
            }
        }
        return false;
    }

    private void SpawnPrefab()
    {
        currentPrefabs++;
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction = -direction;
        }
        if (collision.gameObject.CompareTag("Bubble"))
        {
            lives--;

            if (lives <= 0)
            {
                isDead = true;
            }
        }
    }
}
