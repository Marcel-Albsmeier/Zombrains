using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponSwitcher : MonoBehaviour{


    [SerializeField] InputAction scrollWheel;
    
    [SerializeField] int currentWeaponIndex = 0;


    void Start(){
        SetActiveWeapon();
    }

    // Update is called once per frame
    void Update() {
        int lastWeaponIndex = currentWeaponIndex;

        ProcessKeyInput();
        //ProcessScrollWheel();

        if (lastWeaponIndex != currentWeaponIndex) {
            SetActiveWeapon();
        }
    }

    private void ProcessScrollWheel() {
        throw new NotImplementedException();
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
        List<GameObject> weapons = new List<GameObject>();
        foreach (Transform child in transform) {
            weapons.Add(child.gameObject);
            
        }
        for (int i = 0; i < weapons.Count; i++) {
            Debug.Log(weapons[i].name + " at index " + i );
        }
        

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
