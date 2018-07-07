using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMotor))]
public class FocusDirection : MonoBehaviour {
    Transform target;
    PlayerMotor motor;
    
	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
    void Update()
    {
        print(PlayInteraction.Focussing);
        if (PlayInteraction.Focussing == true)
        {
            motor.FollowTarget(PlayInteraction.FocussingOn);
            motor.FaceTarget();
        }
        else
        {
            motor.StopFollowingTarget();
        }
    }


}
