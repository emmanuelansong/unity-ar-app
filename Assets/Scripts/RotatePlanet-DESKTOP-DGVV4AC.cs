using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatePlanet : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject pivot;

    //public GameObject marker;
    public Transform mainCamera;
    public List<Transform> markers = new List<Transform>();
    Quaternion rotationA, rotationB;
    // Start is called before the first frame updates
    void Start()
    {
        
        foreach (Transform child in transform)
        {
            if(child.tag == "Marker")
            {
                markers.Add(child);
            }
            
        }

       
        mainCamera = Camera.main.transform;
        if (pivot == null)
        {
            pivot = gameObject;
        }



    }
    private void Update()
    {
        //var angle = Quaternion.Angle(marker.transform.rotation, mainCamera.transform.rotation);
        Debug.DrawRay(transform.position, mainCamera.transform.position);
        //each child in earth
        foreach (Transform x in markers)
        {
            
            {
                //mainCamera.transform.position = x.transform.position + new Vector3(0, 1, 0);

                //mainCamera.transform.LookAt(x.transform);
                //transform.rotation = Quaternion.Slerp(rotationA, rotationB, Time.time * 0.1f);
                

            }
            //RaycastHit hit;
                /*if marker hit planet 
                if (Physics.Raycast(x.transform.position, transform.position - x.transform.position, out hit))
                {

                    //calculate angle
                }*/
            
        }

        //rotate yaw
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);

        //rotate around pivot
        transform.RotateAround(pivot.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);

        /*var toCamera = Quaternion.LookRotation(mainCamera.transform.position - marker.transform.position);
        var toSite = Quaternion.LookRotation(mainCamera.transform.localPosition);

        var fromSite = Quaternion.Inverse(toSite);
        .rotation = toCamera * fromSite;*/
    }

    private void OnDrawGizmos()
    {
        foreach (Transform x in markers)
        {
           
            if (x.name == "AntarcticaMarker")
            {
                //transform.rotation = Q1 * Q2;

            }
            //RaycastHit hit;
            /*if marker hit planet 
            if (Physics.Raycast(x.transform.position, transform.position - x.transform.position, out hit))
            {

                //calculate angle
            }*/

        }
    }
}
