using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseRange= 5f;
    bool IsProvoked = false;
    NavMeshAgent navMeshAgent;
    [SerializeField] float turnSpeed=3f;
    float distanceToEnemy=Mathf.Infinity;
    EnemyHealth health;
    void Start()
    {
        navMeshAgent =GetComponent<NavMeshAgent>();
        health=GetComponent<EnemyHealth>();
        target=FindObjectOfType<PlayerHealth>().transform;
              
    }  
    void Update()
    {
        if (health.IsDead())
        {
            enabled=false;
            navMeshAgent.enabled=false;
        }
        distanceToEnemy=Vector3.Distance(target.position,transform.position);
        if (IsProvoked)
        {
            EngageTarget();
        }
        else if (distanceToEnemy<=chaseRange)
        {
            IsProvoked=true;
        }
        
    }
    public void OnDamageTaken()
    {
        
        IsProvoked=true;
        
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToEnemy>=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToEnemy<=navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack",false);
        navMeshAgent.SetDestination(target.position);
        
    }
    private void FaceTarget()
    {
        Vector3 direction=(target.position-transform.position).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*turnSpeed);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, chaseRange);
        
    }
} 