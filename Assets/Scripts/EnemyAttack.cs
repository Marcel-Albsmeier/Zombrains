using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class EnemyAttack : MonoBehaviour{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;


    public bool AttackHitEvent() {
        if (!target) {
            return false;
        }

        Debug.Log("Bang bang");
        return true;
    
    }

   
}
