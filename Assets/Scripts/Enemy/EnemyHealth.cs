using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour{
    //parameters
    [SerializeField] float hitPoints = 100f;
    static string DAMAGE_TAKEN_METHOD = "OnDamageTaken";
    static string DEATH_HANDLING_METHOD = "OnDeath";

    //states
    float currentHitPoints;
    bool isDead;

    private void Awake() {
        currentHitPoints = hitPoints;
        //Debug.Log(currentHitPoints + ";" + this.name);
    }

    

    public void TakeDamage(float damageAmount) {

        if (isDead) {
            return;
        }

        //Debug.Log($"taking {damageAmount} damage");
        currentHitPoints -= damageAmount;
        //Debug.Log($"I have {currentHitPoints} hp remaining");

        BroadcastMessage(DAMAGE_TAKEN_METHOD);

        

        if (currentHitPoints <= 0) {
            //Debug.Log("blargh I died");
            BroadcastMessage(DEATH_HANDLING_METHOD);
            isDead = true;

        }

    }


}
