using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerText : MonoBehaviour
{
    public Transform Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var lookDir = Camera.main.transform.position - Text.position;
        lookDir.y = 0;

        Text.rotation = Quaternion.LookRotation(-lookDir);
        



        //Text.rotation = Quaternion.LookRotation(Camera.main.transform.position, Vector3.forward);
    }
}
