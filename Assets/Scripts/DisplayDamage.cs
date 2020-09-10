using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float damageImgScreenTime=.3f;
    void Start()
    {
        damageCanvas.enabled=false;
    }

    public void ShowDamageSplatter()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator  ShowSplatter()
    {
        damageCanvas.enabled=true;
        yield return new WaitForSeconds(damageImgScreenTime);
        damageCanvas.enabled=false;
    }

}
