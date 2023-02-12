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
        if (carapuce.pp >= 5 && Input.GetButtonDown("Fire1"))
        {
            carapuce.removePP(5);
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
    }
}
