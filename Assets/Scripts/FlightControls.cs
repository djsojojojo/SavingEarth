using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControls : MonoBehaviour
{
    [Header("Plane Stats")]
    [Tooltip("How much throttle ramps up and down.")]
    public float throtteleIncrement = 0.1f;
    [Tooltip("Maximum engine throttle")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 10f;
    public float rollResponse = 1f;
    public float pitchResponse = 1f;
    public float yawResponse = 1f;

    public float throttle;
    public float roll;
    public float pitch;
    public float yaw;

    public float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }


    }
    Rigidbody rb;

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
    }

    private void FixedUpdate()
    {
        // Apply forces to our plane
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier * yawResponse);
        rb.AddTorque(transform.right * pitch * responseModifier * pitchResponse);
        rb.AddTorque(-transform.forward * roll * responseModifier * yawResponse);
    }


}