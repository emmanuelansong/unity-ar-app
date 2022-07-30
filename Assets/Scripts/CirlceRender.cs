using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CirlceRender : MonoBehaviour
{
    public int vertexCount = 100;

    public float width;

    public float radius;

    LineRenderer lineRenderer;

    public Transform centre;

    public Material material;

    public float xOffset;

    // Start is called before the first frame update
    void Start()
    {
        
        radius = centre.transform.position.x + transform.position.x;
        foreach (Transform child in transform)
            lineRenderer = child.gameObject.AddComponent<LineRenderer>();

        lineRenderer.enabled = true;
        
       lineRenderer.widthMultiplier = width;
        
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta) + xOffset, 0, radius * Mathf.Sin(theta));

            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }

        foreach(Transform child in transform)
            lineRenderer.material = child.GetChild(0).GetComponent<Renderer>().material;
        
    }

    private void OnDrawGizmos()
    {
        
        foreach (Transform child in transform)
        {
            if (gameObject.name != "Earth")
            {
                foreach (Transform subChild in child)
                {
                    //centre -> planet position
                    radius = Vector3.Distance(subChild.transform.position, transform.position);
                    float deltaTheta = (2f * Mathf.PI) / vertexCount;
                    float theta = 0f;

                    Vector3 oldPos = centre.position;
                    for (int i = 0; i < vertexCount; i++)
                    {
                        
                        Vector3 pos = new Vector3(radius * Mathf.Cos(theta) * xOffset, 0, radius * Mathf.Sin(theta));
                        Gizmos.DrawLine(oldPos, centre.position + pos);
                        oldPos = centre.position + pos;

                       
                        theta += deltaTheta;
                    }

                }
            }
        }
           
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
