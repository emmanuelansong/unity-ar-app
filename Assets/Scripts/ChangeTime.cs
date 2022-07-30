using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = Time.timeScale * 2;

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Time.timeScale = 1;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;

        }
    }
}
