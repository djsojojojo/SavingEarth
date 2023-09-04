using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject[] asteroid;
    public GameObject earth;

    public static GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if(gameManager != this)
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        earth = GameObject.Find("Earth");
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
