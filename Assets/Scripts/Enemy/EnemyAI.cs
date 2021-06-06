using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyAI : MonoBehaviour{
    //parameters
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float timeUntilCalm = 5f;
    [SerializeField] float turnSpeed = 5f;

    const string CHASE_TRIGGER = "move";
    const string IDLE_TRIGGER = "idle";
    const string ATTACK_STATE = "attack";


    //cached
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    Animator animator;

    //states
    bool isProvoked = false;
    float playerGoneTimer;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        target = FindObjectOfType<RigidbodyFirstPersonController>().transform;
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
            //Debug.Log($"{name} hasn't seen {target.name} in {playerGoneTimer} seconds");
        } else {
            playerGoneTimer = 0;
        }

        if (playerGoneTimer >= timeUntilCalm) {
            isProvoked = false;
            navMeshAgent.SetDestination(transform.position);
            animator.SetTrigger(IDLE_TRIGGER);
            Debug.Log($"{name} has calmed down and stopped chasing");
        }
    }

    private void EngageTarget() {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();

        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
           
            Attack();
        }
    }

    public void OnDamageTaken() {
        isProvoked = true;
        playerGoneTimer = 0f ;
    }


    private void Attack() {
        animator.SetBool(ATTACK_STATE, true);
    }

    private void ChaseTarget() {
        animator.SetBool(ATTACK_STATE, false);
        animator.SetTrigger(CHASE_TRIGGER);
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
