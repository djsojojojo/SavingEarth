using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript2 : MonoBehaviour
{
    public Transform target; // t�h�n laitetaan target joka seuraa hiirt�
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
