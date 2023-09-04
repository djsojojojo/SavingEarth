using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlightControls : MonoBehaviour
{
    [Header("GameMode")]
    public bool twinStick = false;
    public bool mouseAim = true;
    public bool classic = false;

    [Header("Shooting Variables")]
    public GameObject weapon1; // machinegun
    public GameObject weapon2; // missiles
    public GameObject weapon3; // droppable bomb
    public Transform gun; // machinegun
    public Transform missile1; // missile 1
    public Transform missile2; // missile 2
    public Transform missile3; // missile 3
    public Transform missile4; // missile 4
    public Transform nuke; // droppable bomb
    public float firerate = 0.5f; // s‰‰t‰‰ ampumisnopeutta
    public float firerate2 = 1.5f; // s‰‰t‰‰ ampumisnopeutta
    public bool canFire = true;
    public int missiles = 4;
    public int nukes = 1;


    [Header("Flight control variables")]
    public float throtteleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float responsiveness = 10f;
    public float rollResponse = 1f;
    public float pitchResponse = 1f;
    public float yawResponse = 1f;
    public float throttle =0;
    public float roll;
    public float pitch;
    public float yaw;
    Rigidbody rb;

    [Header("UI")]
    public TextMeshProUGUI throttleText;
    public TextMeshProUGUI missilesLeft;
    public TextMeshProUGUI nukesLeft;

    [Header("Effects")]
    
    public GameObject[]  thrusters;
   
    [Header("Camera")]
    public CameraController cameraScript;



    // Start is called before the first frame update
    void Start()
    {
        if (twinStick == true)
        {
            gun.GetComponent<twinStickAim>().enabled = true;
            gun.GetComponent<GunScript2>().enabled = false;
        }
        else if (classic == true)
        {
            gun.GetComponent<twinStickAim>().enabled = false;
            gun.GetComponent<GunScript2>().enabled = false;
        }

    }




    public float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }


    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs()
    {
        // Set rotational values from axis inputs
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        // Handle throttle value being sure to clamp it between 0 and 100
        if (Input.GetButton("Throttle+")) throttle += throtteleIncrement;
        else if (Input.GetButton("Throttle-")) throttle -= throtteleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
       // cameraScript.speed = throttle * -1.2f;
    }

    private void Update()
    {
        HandleInputs();

        if (!twinStick && Input.GetButton("Fire1") && canFire)
        {
            StartCoroutine("Shoot");
        }
        if (!twinStick && Input.GetButton("Fire2") && canFire && missiles >=1)
        {
            StartCoroutine("Shoot2");
        }
        if (!twinStick && Input.GetButton("Fire3") && canFire && nukes >= 1)
        {
            StartCoroutine("Shoot3");
        }
        /*if (throttle > 0)
        {
            thrusters[0].SetActive(true);
        }
        else if (throttle <= 0)
            thrusters[0].SetActive(false);
        /* if (throttle <=9)
        {
            trails[0].SetActive(false);
            trails[1].SetActive(false);
        }
        else if (throttle >9)
        {
            trails[0].SetActive(true);
            trails[1].SetActive(true);
        }*/
    }

    private void FixedUpdate()
    {

        // Apply forces to spaceship
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier * yawResponse);
        rb.AddTorque(transform.right * pitch * responseModifier * pitchResponse);
        rb.AddTorque(-transform.forward * roll * responseModifier * yawResponse);
        throttleText.text = "Throttle % " + throttle.ToString("F1");
        missilesLeft.text = "Missiles " + missiles.ToString();
        nukesLeft.text = "Bombs " + nukes.ToString();


    }


    public IEnumerator Shoot()
    {
        // print("Shoot"); // Prints shoot when fire1 is pressed
        //Instantiate(bullet, transform.position, transform.rotation); // t‰ll‰ pelaajan sijaintiin
        Instantiate(weapon1, gun.position, gun.rotation); //T‰ll‰ aseen sijaintiin
        canFire = false; // ei anna ampua
        yield return new WaitForSeconds(firerate); //odottaa hetken
        canFire = true; // antaa ampua
    }
    public IEnumerator Shoot2()
    {
        // print("Shoot"); // Prints shoot when fire2 is pressed
        //Instantiate(bullet, transform.position, transform.rotation); // t‰ll‰ pelaajan sijaintiin
        Instantiate(weapon2, missile1.position, missile1.rotation); //T‰ll‰ aseen sijaintiin
        missiles -= 1;
        canFire = false; // ei anna ampua
        yield return new WaitForSeconds(firerate2); //odottaa hetken
        canFire = true; // antaa ampua
    }

    public IEnumerator Shoot3()
    {
        // print("Shoot"); // Prints shoot when fire3 is pressed
        //Instantiate(bullet, transform.position, transform.rotation); // t‰ll‰ pelaajan sijaintiin
        Instantiate(weapon3, nuke.position, nuke.rotation); //T‰ll‰ aseen sijaintiin
        nukes -= 1;
        canFire = false; // ei anna ampua
        yield return new WaitForSeconds(firerate); //odottaa hetken
        canFire = true; // antaa ampua
    }


}