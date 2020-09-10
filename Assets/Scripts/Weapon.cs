using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range=100f;
    [SerializeField] float damage=10f;
    [SerializeField] ParticleSystem shotFX;
    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots=0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    bool canShoot=true;
    void OnEnable()
    {
        canShoot=true;
    }
    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0)&& canShoot==true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo=ammoSlot.currentAmmo(ammoType);
        ammoText.text=currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot=false;
        if (ammoSlot.currentAmmo(ammoType)>0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.reduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot=true;
        

    }

    private void PlayMuzzleFlash()
    {
        shotFX.Play();
        
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)){
            ParticleSystem impact = Instantiate(hitVFX,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(impact.gameObject,1);
        }
    }
}
