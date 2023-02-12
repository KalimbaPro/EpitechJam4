using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public stats carapuce;
    public int health = 3;
    

    public void TakeDamage(int d)
    {
        health -= d;

        if (health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Carapuce")
        {
            carapuce.time += 15;
        }
    }
    void Die()
    {
        carapuce.ekilled += 1;
        Destroy(gameObject);
    }
}
