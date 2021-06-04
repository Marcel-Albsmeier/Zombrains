using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponSwitcher : MonoBehaviour{


    [SerializeField] InputAction scrollWheel;
    

    //states
    [SerializeField] int currentWeaponIndex = 0;
    int weaponCount;

    private void Awake() {
        scrollWheel.Enable();
    }

    private void OnDisable() {
        scrollWheel.Disable();
    }

    void Start(){
        weaponCount = 0;
        SetActiveWeapon();
        GetWeaponCount();
    }

    private void GetWeaponCount() {
       foreach (Transform weapon in transform) {
            weaponCount++;
        }
    }


    // Update is called once per frame
    void Update() {
        int lastWeaponIndex = currentWeaponIndex;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (lastWeaponIndex != currentWeaponIndex) {
            SetActiveWeapon();
        }
    }

    private void ProcessScrollWheel() {
        float scrollInput = scrollWheel.ReadValue<Vector2>().y;
        Debug.Log(scrollInput);
        if (scrollInput > 0) {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0 ) {
                currentWeaponIndex = weaponCount - 1;
            }
        }else if (scrollInput < 0) {
            currentWeaponIndex++;
            Debug.Log($"weapon index = {currentWeaponIndex}");
            if (currentWeaponIndex >= weaponCount) {
                currentWeaponIndex = 0;
            }
        }
    }

    private void ProcessKeyInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeaponIndex = 0;
        }else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeaponIndex = 1;
        }else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            currentWeaponIndex = 2;
        }
    }

    private void SetActiveWeapon() {
        int weaponIndex = 0;   

        foreach (Transform weapon in transform) {
            if (weaponIndex == currentWeaponIndex) {
                weapon.gameObject.SetActive(true);
            } else {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
        

    }


}
