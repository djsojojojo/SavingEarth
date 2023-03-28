using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("GameMode")]
    public bool twinStick = false;
    public bool mouseAim = true;
    public bool classic = false;

    [Header("Player Movement Variables")]
    // Variables
    [Range(0.1f, 30f)] // Range makes slider to next variable
    public float playerSpeed = 10f;

    [Header("Shooting Variables")]
    public GameObject bullet;
    public Transform gun;
    public float firerate =0.5f; // s‰‰t‰‰ ampumisnopeutta
    public bool canFire = true;
    

    // Start is called before the first frame update
    void Start()
    {
        if(twinStick==true)
        {
            gun.GetComponent<twinStickAim>().enabled = true;
            gun.GetComponent<GunScript2>().enabled = false;
        }
        else if(classic == true)
        {
            gun.GetComponent<twinStickAim>().enabled = false;
            gun.GetComponent<GunScript2>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // This is for moving player

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float dep = Input.GetAxis("Depth");
        // hor is for horizontal and ver is for vertical dep is for depth
        // print(hor); // Prints horizontal value
        // print(ver); // Prints vertical value
        // print(dep); // Prints depth value

        // This moves player left and right, up and down and possibility to move in and out
        transform.Translate(new Vector3(hor * playerSpeed * Time.deltaTime, ver * playerSpeed * Time.deltaTime, dep * playerSpeed * Time.deltaTime));

        // This is for shooting

        if(!twinStick && Input.GetButton("Fire1")&& canFire)
        {
            StartCoroutine("Shoot");
        }

    }

    // This is for shooting settings
    public IEnumerator Shoot()
    {
        // print("Shoot"); // Prints shoot when fire1 is pressed
        //Instantiate(bullet, transform.position, transform.rotation); // t‰ll‰ pelaajan sijaintiin
        Instantiate(bullet, gun.position, gun.rotation); //T‰ll‰ aseen sijaintiin
        canFire = false; // ei anna ampua
        yield return new WaitForSeconds(firerate); //odottaa hetken
        canFire = true; // antaa ampua
    }


}
