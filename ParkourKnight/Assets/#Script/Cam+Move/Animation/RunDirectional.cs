using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDirectional : MonoBehaviour {
    public Animator anim;
    private float inputV;
    private float inputH;
    private bool run = false;
    private bool roll = false;

	void Start () {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        Walking();
        if (Input.GetButtonDown("roll"))
        {
            roll = true;
        }
        else { roll = false; }
        if (Input.GetButton("sprint"))
        {
            run = true;
        }
        else { run = false; }
        anim.SetBool("roll", roll);
        anim.SetBool("run", run);

    }
    void Walking()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
    }
}
