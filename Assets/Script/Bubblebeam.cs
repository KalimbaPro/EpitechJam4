using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubblebeam : MonoBehaviour
{
    public stats carapuce;
    public Transform firePoint;
    public GameObject bubblePrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            firePoint.LookAt(player.transform.position);
        }
        Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
    }
}
