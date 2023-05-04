using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarScript : MonoBehaviour
{

    public Transform target;
    public float offset = 50f;
    public Transform enemy;
    public GameObject radarPoint;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y+offset, target.position.z);
        Vector3 targetposition = new Vector3(target.position.x, target.position.y, target.position.z);
        radarPoint.transform.LookAt(targetposition);
    }
}
