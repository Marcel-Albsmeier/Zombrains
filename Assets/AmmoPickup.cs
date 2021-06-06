using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour{
    //constants
    const string PERMITTED_COLLISION_TAG = "Player";

    //parameters
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other) {
        var collidedObject = other.gameObject;
        if (!collidedObject.CompareTag(PERMITTED_COLLISION_TAG)) {
            return;
        }

        FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);

        Destroy(gameObject);
    }
}
