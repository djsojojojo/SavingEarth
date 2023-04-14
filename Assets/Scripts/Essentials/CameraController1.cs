using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float cameradelay;
    public Camera[] cameras;
    public GameObject[] postEffects;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        cameras[1].enabled = false; // kytkee toisen kameran pois p‰‰‰lt‰ kun peli k‰ynnistet‰‰n

        postEffects[1].SetActive(false); // kytkee postprocessingin pois p‰‰lt‰ kun peli k‰ynnistet‰‰n

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, cameradelay * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C))
        {
            DisableCameras();
            cameras[1].enabled = true;
            ui.SetActive(false);
            postEffects[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            DisableCameras();
            cameras[0].enabled = true;
            ui.SetActive(true);
            postEffects[0].SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            DisableCameras();
            cameras[2].enabled = true;
            ui.SetActive(false);
            postEffects[2].SetActive(true);

        }
    }
    public void DisableCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
            postEffects[i].SetActive(false);
        }
    }
}
