using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FocusDirection : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    // how agressive the camera LockOn is
    public float lockOnPower = 5;

    // Use this for initialization
    void Start()
    {
        // simply, the agent represnts the character
        agent = GetComponent<NavMeshAgent>();
    }
    // Runs each frame
    void Update()
    {
        // checking for a target before checking whether it's an enemy
        if (PlayInteraction.Focussing == true)
        {

            if (PlayInteraction.FocussingOn.Enemy == true)
            {
                // runs function so character moves towards enemy
                FollowTarget(PlayInteraction.FocussingOn);
                // runs function so camera will lock on the enemy 
                FaceTarget();

            }                
        }
        else
        {
            // if there's no target then player won't move
            StopFollowingTarget();
        }
    }

    // moves to target stops just inside of the target radius
    // and player can move any inside while locked on
    public void FollowTarget(InteractableObject newTarget)
    {
        target = newTarget.transform;
        agent.stoppingDistance = newTarget.radius * 0.9f;
        agent.SetDestination(target.position);
    }

    // remove all pathfinding and targetting
    // player can move and look freely now
    public void StopFollowingTarget()
    {
        agent.updateRotation = true;
        agent.ResetPath();
        target = null;
    }


    void FaceTarget()
    {
        // finds the direction of the target from the character
        Vector3 direction = (target.position - transform.position).normalized;
        // sets a variable for the rotation that will happen
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        // turns, smoothly (Slerp)
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lockOnPower);
    }
}