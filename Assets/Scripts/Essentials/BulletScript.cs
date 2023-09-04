using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public GameObject[] asteroid;
    public GameObject earth;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*bulletSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    public void SpawnAsteroid()
    {
        int rnd = Random.Range(0, 4);
        Instantiate(asteroid[rnd], new Vector3(
            earth.transform.position.x,
            earth.transform.position.y + 8,
            earth.transform.position.z), earth.transform.rotation);
    }

}
