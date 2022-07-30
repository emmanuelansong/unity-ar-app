using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float rotationSpeed;

    public float minRadius;
    public float maxRadius;
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name != "Sun")
        {
            //RandomPoint(pivot.transform.position, minRadius, maxRadius);
            
        }
    }

    // Update is called once per frame


    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
        transform.RotateAround(pivot.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
        

    }

    public Vector3 RandomPoint(Vector3 origin, float minRadius, float maxRadius)
    {
        var randomDirection = (Random.insideUnitSphere + origin);
        Debug.Log(randomDirection);
        var randomDistance = Random.Range(minRadius, maxRadius);

        //Sample reference point + random offset * rad
        var sample = origin + randomDirection * randomDistance;

        //Then set the y to sampled terrain height
        sample.y = 0;//terrain.SampleHeight(sample);
        
        //And return the sample!
        gameObject.transform.position = sample;
        Debug.Log(sample);
        return sample;

    }
}
