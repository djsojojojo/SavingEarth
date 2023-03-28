using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript2 : MonoBehaviour
{
    public Transform target; // tähän laitetaan target joka seuraa hiirtä
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
