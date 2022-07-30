using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerRecognition : MonoBehaviour
{
    public Transform marker;

    private void Start()
    {
        marker = marker.transform.GetChild(0);
    }

}
