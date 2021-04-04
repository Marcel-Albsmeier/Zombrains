using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour{

    //parameters
    [SerializeField] InputAction shootWeapon;
    [SerializeField] Camera fpCamera;
    [SerializeField] float weaponDamage = 35f;
    [SerializeField] float weaponRange = 100f;
    [SerializeField] ParticleSystem muzzleFlash;

    private void Awake() {
        shootWeapon.Enable();
    }

    private void OnDisable() {
        shootWeapon.Disable();
    }

    void Update(){
        if (shootWeapon.triggered) {
            Shoot();
        }
    }

    private void Shoot() {
        PlayMuzzleFlash();
        ProcessRaycast();

    }

    private void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }

    private void ProcessRaycast() {
        RaycastHit hit;

        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, weaponRange)) {
            Debug.Log($"I hit {hit.transform.name}");
            //TODO: Add hit effect visual to help player notice hits

            EnemyHealth targetHealth = hit.transform.GetComponent<EnemyHealth>();

            if (targetHealth) {
                targetHealth.TakeDamage(weaponDamage);
            }

        } else {
            return;
        }
    }
}
