using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FocusDirection : MonoBehaviour {
    Transform target;
    NavMeshAgent agent;
    public float lockOnPower = 5;
    
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
		
	}
    void Update()
    {
        if(PlayInteraction.Focussing == true)
        {
            target = PlayerCasting.hit.collider.GetComponent<Transform>();
        
            //FaceTarget();
        }
    }
    public void FollowTarget(InteractableObject newTarget)
    {
        agent.updateRotation = false;
        target = newTarget.transform;
    }
    public void StopFollowingTarget()
    {
        agent.updateRotation = true;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lockOnPower);
    }
}
