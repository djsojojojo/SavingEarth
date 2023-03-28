using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(myray, out hit, Mathf.Infinity, layerMask)) // This makes moving cursor possible
        { // This code makes gameobjects destroied when clicked with mouse1 if tag is Enemy
           // if(Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy"))
            {
             //   Destroy(hit.transform.gameObject);
            }
           transform.position = hit.point;
           // transform.position = Vector3.Lerp(transform.position, hit.point, 0.1f); //Smoother movement
           // print("Hit Something");
        }

        // Debug.DrawRay(Camera.main.transform.position, Vector3.forward, Color.red, 10000f); // Debug use, lenght not working proberly

    }
}
