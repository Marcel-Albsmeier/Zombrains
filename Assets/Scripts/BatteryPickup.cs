using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour{
    //constants
    const string PERMITTED_COLLISION_TAG = "Player";

    //parameters
    [SerializeField] float angleRecharge = 25f;
    [SerializeField] float intensityRecharge = 2f;

    private void OnTriggerEnter(Collider other) {
        var collidedObject = other.gameObject;
        if (!collidedObject.CompareTag(PERMITTED_COLLISION_TAG)) {
            return;
        }
        Debug.Log("Player collided with battery");

        other.GetComponentInChildren<FlashLightSystem>().RechargeBattery(angleRecharge, intensityRecharge);
        Destroy(gameObject);

    }

}
