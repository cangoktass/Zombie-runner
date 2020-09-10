using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay=.1f;
    [SerializeField] float angleDecay=1f;
    [SerializeField] float minimumAngle=40f;
    Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight=GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
        
    }
    public void RestoreAngle(float restoreAngle)
    {
        myLight.spotAngle=restoreAngle;
    }
    public void RestoreIntensity(float addIntensity)
    {
        myLight.intensity=addIntensity;
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity-=lightDecay*Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle<=minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle-=angleDecay*Time.deltaTime;
        }

    }
}
