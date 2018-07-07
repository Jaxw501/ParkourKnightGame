using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FocusDirection : MonoBehaviour {
    Transform target;
    NavMeshAgent agent;
    public float lockOnPower = 5;
    PlayerMotor motor;
    
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        motor = GetComponent<PlayerMotor>();
	}
    void Update()
    {
        print(PlayInteraction.Focussing);
        if (PlayInteraction.Focussing == true)
        {
            target = PlayerCasting.hit.collider.GetComponent<Transform>();
            agent.SetDestination(target.position);

            FaceTarget();
        }
        else
        {
            StopFollowingTarget();
        }
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
