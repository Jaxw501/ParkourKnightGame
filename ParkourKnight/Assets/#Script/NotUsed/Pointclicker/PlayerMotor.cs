using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;
    Transform target;
    public float lockOnPower = 5;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
        {
            agent.SetDestination(target.position);
        }
	}
    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void FollowTarget(InteractableObject newTarget)
    {
        agent.updateRotation = false;

        target = newTarget.transform;
        //agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.SetDestination(target.position);

    }
    public void StopFollowingTarget()
    {
        agent.updateRotation = true;
        agent.ResetPath();
        target = null;
    }
    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lockOnPower);
    }
}
