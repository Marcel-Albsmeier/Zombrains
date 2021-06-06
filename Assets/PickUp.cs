using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour{

    const string PERMITTED_COLLISION_TAG = "Player";
    private void OnTriggerEnter(Collider other) {
        var collidedObject = other.gameObject;
        if (!collidedObject.CompareTag(PERMITTED_COLLISION_TAG)) {
            return;
        }

        Destroy(gameObject);
    }
}
