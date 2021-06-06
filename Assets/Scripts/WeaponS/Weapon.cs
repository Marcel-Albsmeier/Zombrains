using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour{

    //parameters
    [SerializeField] InputAction shootWeapon;
    [SerializeField] Camera fpCamera;
    [SerializeField] float weaponDamage = 25f;
    [SerializeField] float weaponRange = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;
    [SerializeField] float shotRecoveryTimer = 1f;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    bool canShoot = true;

    private void Awake() {
        shootWeapon.Enable();
    }

    private void OnDisable() {
        shootWeapon.Disable();
    }

    private void OnEnable() {
        shootWeapon.Enable();
        canShoot = true;
    }

    void Update() {
        //Debug.Log($"Can shoot is {canShoot}");
        if (shootWeapon.triggered && canShoot) {
            //Debug.Log("Shooting now");
            StartCoroutine(Shoot());

        }
    }

    private IEnumerator Shoot() {

        if (ammoSlot.GetCurrentAmmoCount(ammoType) > 0) {
            canShoot = false;
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            ProcessRaycast();
        }

        yield return new WaitForSeconds(shotRecoveryTimer);
        canShoot = true;

    }

    private void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }

    private void ProcessRaycast() {
        RaycastHit hit;

        

        if (Physics.Raycast((fpCamera.transform.position + (fpCamera.transform.forward/2)), fpCamera.transform.forward, out hit, weaponRange)) {
            CreateHitImpactVFX(hit);
            //Debug.Log($"I hit {hit.transform.name}");
            //TODO: Add hit effect visual to help player notice hits

            EnemyHealth targetHealth = hit.transform.GetComponent<EnemyHealth>();

            if (targetHealth) {
                //Debug.Log($"Dealing {weaponDamage} damage to target");
                targetHealth.TakeDamage(weaponDamage);
            }

        } else {
            return;
        }
    }

    private void CreateHitImpactVFX(RaycastHit hit) {
        var impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
