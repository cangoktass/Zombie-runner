using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;
    [SerializeField] float zoomedOut=60f;
    [SerializeField] float zoomedIn=25f;
    [SerializeField] float mouseSensZoomedIn=1f;
    [SerializeField] float mouseSensZoomedOut=2f;
    [SerializeField] bool zoomedInToggle=false;
    private void OnDisable() {
        ZoomOut();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle==false)
            {
                ZoomIn();

            }
            else
            {
                ZoomOut();

            }


        }
       

        
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOut;
        firstPersonController.mouseLook.XSensitivity = mouseSensZoomedOut;
        firstPersonController.mouseLook.YSensitivity = mouseSensZoomedOut;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedIn;
        firstPersonController.mouseLook.XSensitivity = mouseSensZoomedIn;
        firstPersonController.mouseLook.YSensitivity = mouseSensZoomedIn;
    }
}
