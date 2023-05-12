using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticleController : MonoBehaviour
{
    [SerializeField] Transform[] particleTargets;
    [SerializeField] public float speed;

    private int index = 0;
    private Vector3 target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) index = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) index = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) index = 3;


    }

    private void FixedUpdate()
    {
        target = particleTargets[index].position;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
        transform.forward = particleTargets[index].forward;


    }
}
