using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{
    //parameters
    [SerializeField] [Min(0)] int playerHitPoints = 100;


    //states
    [SerializeField] float currentHitPoints;
    bool isAlive;

    private void Awake() {
        currentHitPoints = playerHitPoints;
    }

    public bool TakeDamage(float amount) {
        currentHitPoints -= amount;

        if (currentHitPoints <= 0) {
            Debug.Log("He's bread jim.");
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log(Cursor.lockState);
            Debug.Log(Cursor.visible);
        }

        return true;   
    }
}
