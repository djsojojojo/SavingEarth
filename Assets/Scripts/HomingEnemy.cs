using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public Transform target;
    public float enemySpeed = 5f;
    public EnemyAim enemyAim;
    public GameObject menu;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //  target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        enemyAim = GameObject.Find("EnemyArrow").GetComponent<EnemyAim>();
        enemyAim.target = transform;
        transform.LookAt(target);
        transform.Translate(Vector3.forward*enemySpeed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            menu.SetActive(true);
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
    }
}
