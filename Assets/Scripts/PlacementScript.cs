using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacementScript : MonoBehaviour
{

    public ARRaycastManager arRaycastManager;
    //Assign camera – should work with main tag but sometimes has issues
    public Camera arCamera;
    public GameObject knightPrefab;

    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
{
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
            
                if (Input.touchCount == 2)
                {
                    if (count == 0)
                    {
                        if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                        {
                            count = 1;
                            //Raycast Planes

                            var pose = arRaycastHits[0].pose;

                            CreateKnight(pose.position);

                            return;

                        }
                    }
                    


                    Ray ray = arCamera.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.tag == "Earth")
                        {
                            DeleteKnight(hit.collider.gameObject);

                        }
                    }
                    
                }
                
            }
        }
    }

    void CreateKnight(Vector3 position)
    {
        var prefab = Instantiate(knightPrefab, position, Quaternion.identity);
    }
    private void DeleteKnight(GameObject knightObject)
    {
        Destroy(knightObject);
    }
}
