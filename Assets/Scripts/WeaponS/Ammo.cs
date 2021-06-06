using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour{

    [SerializeField] int maxAmmo;
    [SerializeField] int currentAmmo = 10;


    public int GetCurrentAmmoCount() {
        return currentAmmo;
    }

    public void ReduceCurrentAmmo(int amount) {
        currentAmmo -= amount;
    }

    public void ReduceCurrentAmmo() {
        currentAmmo--;
    }
}
