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

    // Update is called once per frame
    void Update(){
        
    }
}
