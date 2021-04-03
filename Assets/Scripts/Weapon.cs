using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour{

    //parameters
    [SerializeField] InputAction shootWeapon;
    [SerializeField] Camera fpCamera;
    [SerializeField] float weaponRange = 100f;

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
        RaycastHit hit;
        Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, weaponRange);
        if (hit.transform != null) {
            Debug.Log($"I hit {hit.transform.name}");
        }
        
    }


}
