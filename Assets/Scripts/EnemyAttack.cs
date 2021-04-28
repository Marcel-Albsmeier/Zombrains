using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class EnemyAttack : MonoBehaviour{

    //parameters
    [SerializeField] float damage = 40f;

    //cached
    PlayerHealth target;

    private void Start() {
        target = FindObjectOfType<PlayerHealth>();
    }



    public bool AttackHitEvent() {
        if (!target) {
            return false;
        }
        var tempTargetHealth = target;
        if (!tempTargetHealth) {
            return false;
        }
        tempTargetHealth.TakeDamage(damage);

        return true;
    
    }

    public void OnDamageTaken() {
        Debug.Log("test");
    }


}
