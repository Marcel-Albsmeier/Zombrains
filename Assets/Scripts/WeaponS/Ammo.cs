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
    [SerializeField] AmmoSlot[] ammoSlot;


    //public int getcurrentammocount() {
    //    return currentammo;
    //}

    //public void reducecurrentammo(int amount) {
    //    currentammo -= amount;
    //}

    //public void reducecurrentammo() {
    //    currentammo--;
    //}
}
