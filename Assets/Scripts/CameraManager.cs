using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera subCam;
    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        subCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCam();
        }
    }

    public void ChangeCam()
    {
        if (!subCam.enabled)
        {
            subCam.enabled = true;
            mainCam.enabled = false;
            Canvas.GetComponent<Canvas>().worldCamera = subCam;
        }
        else
        {
            subCam.enabled = false;
            mainCam.enabled = true;
            Canvas.GetComponent<Canvas>().worldCamera = mainCam;
        }
        
    }
}
