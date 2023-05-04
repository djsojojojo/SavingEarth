using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControls : MonoBehaviour
{
    [Header("GameMode")]
    public bool twinStick = false;
    public bool mouseAim = true;
    public bool classic = false;

    [Header("Shooting Variables")]
    public GameObject weapon1;
    public GameObject weapon2;
    public Transform gun;
    public float firerate = 0.5f; // s‰‰t‰‰ ampumisnopeutta
    public bool canFire = true;
    public int missiles = 4;


    [Header("Flight control variables")]
    public float throtteleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float responsiveness = 10f;
    public float rollResponse = 1f;
    public float pitchResponse = 1f;
    public float yawResponse = 1f;
    public float throttle;
    public float roll;
    public float pitch;
    public float yaw;
    Rigidbody rb;

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
        if (Input.GetKey(KeyCode.Space)) throttle += throtteleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throtteleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }
    private void Update()
    {
        HandleInputs();
        if (!twinStick && Input.GetButton("Fire1") && canFire)
        {
            StartCoroutine("Shoot");
        }
        if (!twinStick && Input.GetButton("Fire3") && canFire && missiles >=1)
        {
            StartCoroutine("Shoot2");
        }
    }

    private void FixedUpdate()
    {
        // Apply forces to spaceship
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier * yawResponse);
        rb.AddTorque(transform.right * pitch * responseModifier * pitchResponse);
        rb.AddTorque(-transform.forward * roll * responseModifier * yawResponse);
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
        // print("Shoot"); // Prints shoot when fire1 is pressed
        //Instantiate(bullet, transform.position, transform.rotation); // t‰ll‰ pelaajan sijaintiin
        Instantiate(weapon2, gun.position, gun.rotation); //T‰ll‰ aseen sijaintiin
        missiles -= 1;
        canFire = false; // ei anna ampua
        yield return new WaitForSeconds(firerate); //odottaa hetken
        canFire = true; // antaa ampua
    }
}