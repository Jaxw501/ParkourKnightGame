using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FocusDirection : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public float lockOnPower = 5;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (PlayInteraction.Focussing == true)
        {
            if (PlayInteraction.FocussingOn.Enemy == true)
            {
                FollowTarget(PlayInteraction.FocussingOn);

                FaceTarget();
            }                
        }
        else
        {
            StopFollowingTarget();
        }
    }

    public void FollowTarget(InteractableObject newTarget)
    {

        target = newTarget.transform;
        agent.stoppingDistance = newTarget.radius * 0.9f;
        agent.SetDestination(target.position);
    }

    public void StopFollowingTarget()
    {
        agent.updateRotation = true;
        agent.ResetPath();
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lockOnPower);
    }
}