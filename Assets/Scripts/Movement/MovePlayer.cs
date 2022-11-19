
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{
public class MovePlayer : MonoBehaviour,IAction
{
        private Animator animatorChild;
        private NavMeshAgent NavMesh;
        private Health health;
    void Start()
    {
        NavMesh = GetComponent<NavMeshAgent>();
        animatorChild = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    void Update()
    {
            NavMesh.enabled = !health.isDead();
            UpdateAnimator();  
    }

    public void StartMove(Vector3 destination)
        {
            MoveTo(destination);
            GetComponent<ActionScheduler>().StartAction(this);      
        }
    public void MoveTo(Vector3 destination)
    {
            
            NavMesh.isStopped = false;
       NavMesh.destination = destination;
    }
    public void Cancel()
     {
      NavMesh.isStopped = true;
     }

    private void UpdateAnimator()
    {
        Vector3 speed = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(speed);

        float specialSpeed = localVelocity.z;
        animatorChild.SetFloat("forwardSpeed", specialSpeed);
    }

    

}













}
