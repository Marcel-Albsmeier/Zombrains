using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour{
    //parameters
    [SerializeField] float hitPoints = 100f;


    //states
    float currentHitPoints;

    private void Awake() {
        currentHitPoints = hitPoints;
    }

    public void TakeDamage(float damageAmount) {
        currentHitPoints -= damageAmount;

        if (currentHitPoints <= 0) {
            Debug.Log("blargh I died");
            gameObject.SetActive(false);
        }

    }

}
