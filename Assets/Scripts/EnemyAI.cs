using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{
    //parameters
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;

    //cached
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    //states

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange) {
            navMeshAgent.SetDestination(target.position);
        }
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
