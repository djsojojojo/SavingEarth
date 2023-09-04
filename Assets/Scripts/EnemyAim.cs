using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public Transform target;




    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target); // this follows player

    }


}
