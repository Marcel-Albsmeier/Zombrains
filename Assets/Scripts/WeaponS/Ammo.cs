using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour{

    //private class for AmmoSlots
    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int maxAmmoOfType;
        public int currentAmmoCount;
    }

    //parameters
    [SerializeField] AmmoSlot[] ammoSlots;


    public int GetCurrentAmmoCount(AmmoType ammoType) {

        return GetAmmoSlot(ammoType).currentAmmoCount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
        foreach (AmmoSlot ammoSlot in ammoSlots) {
            if (ammoSlot.ammoType == ammoType ){
                return ammoSlot;
            }
        }
        return null;
    }

    public bool ReduceCurrentAmmo(AmmoType ammoType, int amount) {
        GetAmmoSlot(ammoType).currentAmmoCount -= amount;
        return true;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType) {
        GetAmmoSlot(ammoType).currentAmmoCount--;
    }

    public bool IncreaseCurrentAmmo(AmmoType ammoType, int ammount) {

        var ammoSlot = GetAmmoSlot(ammoType);
        if (ammoSlot.currentAmmoCount == ammoSlot.maxAmmoOfType) {
            return false;
        }
        ammoSlot.currentAmmoCount += ammount;
        if (ammoSlot.currentAmmoCount > ammoSlot.maxAmmoOfType) {
            ammoSlot.currentAmmoCount = ammoSlot.maxAmmoOfType;
        }
        return true;
    }
}
