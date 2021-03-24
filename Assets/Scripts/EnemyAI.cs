using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{
    //parameters
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;
    [SerializeField] float timeUntilCalm = 5;


    //cached
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    //states
    bool isProvoked = false;
    float playerGoneTimer;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked) {
            EngageTarget();
            CalmDown();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;  
        }
        
    }

    private void CalmDown() {
        if (distanceToTarget > chaseRange) {
            playerGoneTimer += Time.deltaTime;
            Debug.Log($"{name} hasn't seen {target.name} in {playerGoneTimer} seconds");
        } else {
            playerGoneTimer = 0;
        }

        if (playerGoneTimer >= timeUntilCalm) {
            isProvoked = false;
            Debug.Log($"{name} has calmed down and stopped chasing");
        }
    }

    private void EngageTarget() {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();

        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            Attack();
        }
    }

    private void Attack() {
        Debug.Log($"{name} just hit, and is currently tearing appart {target.name}");
    }

    private void ChaseTarget() {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
