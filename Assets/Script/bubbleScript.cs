using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleScript : MonoBehaviour
{
    public GameObject carapuce;
    public float speed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        Vector2 direction = carapuce.transform.up;
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Fire fire = hitInfo.GetComponent<Fire>();

        if (hitInfo.name == "Carapuce")
        {
            return;
        }
        if (fire != null)
        {
            fire.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
