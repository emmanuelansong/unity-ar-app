using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;


[RequireComponent(typeof(ARRaycastManager))]

public class PlacementControllerWithMultiple : MonoBehaviour
{
    [SerializeField]

    public List<Button> buttons;
    public List<Button> buttons2;
    public GameObject page_1;
    public GameObject page_2;
    //private GameObject placedPrefab;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public bool markerPlaced;
    void Awake()
    {

        arRaycastManager = GetComponent<ARRaycastManager>();

        buttons[0].onClick.AddListener(() => DoSomething(buttons[0]));
        buttons[1].onClick.AddListener(() => DoSomething(buttons[1]));
        buttons[2].onClick.AddListener(() => DoSomething(buttons[2]));
        buttons[3].onClick.AddListener(() => DoSomething(buttons[3]));
        buttons[4].onClick.AddListener(() => DoSomething(buttons[4]));
        buttons[5].onClick.AddListener(() => DoSomething(buttons[5]));
        buttons[6].onClick.AddListener(() => DoSomething(buttons[6]));
        buttons[7].onClick.AddListener(() => DoSomething(buttons[7]));
        buttons[8].onClick.AddListener(() => DoSomething(buttons[8]));


        buttons2[0].onClick.AddListener(() => DoSomething(buttons2[0]));
        buttons2[1].onClick.AddListener(() => DoSomething(buttons2[1]));
        buttons2[2].onClick.AddListener(() => DoSomething(buttons2[2]));
        buttons2[3].onClick.AddListener(() => DoSomething(buttons2[3]));
        buttons2[4].onClick.AddListener(() => DoSomething(buttons2[4]));
        buttons2[5].onClick.AddListener(() => DoSomething(buttons2[5]));



    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                bool isOverUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                if (isOverUI)
                {
                    Debug.Log(" blocked raycast");
                    return;
                }
                //Check if AR Ray cast hots a trackable plane
                if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                {
                    Debug.Log("ar raycast");
                    var hitPose = hits[0].pose;
                    Debug.Log("placed prefab");
                    //Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                }

            }
        }

    }
    public void DoSomething(Button button)
    {

        Color buttonColour = button.image.color;

        if (button == null)
        {
            Debug.LogError($"Prefab with name {button} could not be loaded");
        }

        Debug.Log(button.name);


        switch (button.name)
        {

            case "NA":

                DisableOthers(button);
                break;
            case "SA":

                DisableOthers(button);

                break;

            case "AF":

                DisableOthers(button);
                break;
            case "ME":

                DisableOthers(button);
                break;
            case "AS":

                DisableOthers(button);
                break;
            case "EU":

                DisableOthers(button);
                break;
            case "AN":

                DisableOthers(button);
                break;
            case "AU & OC":

                DisableOthers(button);
                break;

            case "NextPage":

                SwitchPage(button);

                break;
            case "IO":
                Debug.Log("test");
                DisableOthers2(button);
                break;
            case "SO":
                Debug.Log("test");
                DisableOthers2(button);
                break;
            case "AO":
                DisableOthers2(button);
                break;
            case "PO":
                DisableOthers2(button);
                break;
            case "ARC":
                DisableOthers2(button);
                break;
            case "GoBack":
                SwitchPage(button);
                break;
        }



        //button.image.col



        //button.image.color = Na;
    }
    /*void ChangePrefabTo(string prefabName)
    {
        placedPrefab = Resources.Load<GameObject>($"assets/{prefabName}");
        if (placedPrefab == null)
        {
            Debug.LogError($"Prefab with name {prefabName} could not be loaded, make sure you check the naming of your prefabs...");
        }
 
        //create temp color var to access alpha.
        Color play = playButton.image.color;
        Color pause = pauseButton.image.color;
        
        switch (prefabName)
        {
            case "Wayne":
                Debug.Log("is wayne");
                //Logger.Instance.LogInfo( ("is wayne");
                wc.a = 1f;
                pc.a = 0.5f;
                break;
            case "Patrick":
                Debug.Log("is pat");
                //Logger.Instance.LogInfo( ("is Patrick");
                wc.a = 0.5f;
                pc.a = 1f;
                break;
        }
        wayneBtn.image.color = wc;
        patrickBtn.image.color = pc;
    }*/
    void SwitchPage(Button button)
    {
        Button tempButton = button;
        if (button.name == "NextPage")
        {
            page_1.SetActive(false);

            page_2.SetActive(true);
            page_2.transform.Find("GoBack").transform.GetChild(0).gameObject.SetActive(true);
        }
        if (button.name == "GoBack")
        {
            page_1.SetActive(true);
            page_2.SetActive(false);
            page_1.transform.Find("NextPage").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void DisableOthers2(Button button)
    {
        foreach (var x in buttons2)
        {

            Debug.Log("page 2 active");
            var marker = x.gameObject.GetComponent<markerRecognition>().marker;
            marker.gameObject.SetActive(false);

            if (x.name != button.name)
            {
                //if (button.name != "Next Page" || button.name != "Go Back")
                //{
                marker.gameObject.SetActive(false);
                Color xColour = x.image.color;
                xColour.a = 0.5f;
                x.image.color = xColour;
            }

            if (x.name == button.name)
            {
                marker.gameObject.SetActive(true);
                Color xColour = x.image.color;
                xColour.a = 1f;
                x.image.color = xColour;
            }

            if (x.transform.name == "GoBack")
            {
                marker.gameObject.SetActive(false);
                Color xColour = x.image.color;
                xColour.a = 1f;
                x.image.color = xColour;
            }

        }

    }


    void DisableOthers(Button button)
    {
        foreach (var x in buttons)
        {
            var marker = x.gameObject.GetComponent<markerRecognition>().marker;


            if (x.name != button.name && x.transform.name != "NextPage")
            {
                //if (button.name != "Next Page" || button.name != "Go Back")
                //{
                marker.gameObject.SetActive(false);
                Color xColour = x.image.color;
                xColour.a = 0.5f;
                x.image.color = xColour;
            }

            if (x.name == button.name)
            {
                marker.gameObject.SetActive(true);
                
                Color xColour = x.image.color;
                xColour.a = 1f;
                x.image.color = xColour;
            }

            if (x.transform.name == "NextPage")
            {
                marker.gameObject.SetActive(false);
                Color xColour = x.image.color;
                xColour.a = 1f;
                x.image.color = xColour;
            }


        }

    }
        
    
}