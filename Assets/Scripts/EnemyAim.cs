using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public Transform target;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // this follows player
        InvokeRepeating("Shoot", 1f, 1f); // This shoot once per second, starting in one second after start
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target); // this follows player

    }
    public void Shoot()
    {
       Instantiate(bullet, transform.position, transform.rotation);
    
   
    }

}
