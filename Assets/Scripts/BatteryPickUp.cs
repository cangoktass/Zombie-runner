using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] float restoreAngle=68f;
    [SerializeField] float addIntensity=3f;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreIntensity(addIntensity);
            Destroy(gameObject);
            
        }
    }
}
