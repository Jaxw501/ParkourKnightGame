using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDirectional : MonoBehaviour {
    public Animator anim;
    private float inputV;
    private float inputH;
    public static float speedIncrease = 0;
    private bool run;
    private bool roll;

	void Start () {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        Walking();
        CanRun();
        CanRoll();
        
    }
    void Walking()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
    }


    void CanRun()
    {
        if (Input.GetButton("sprint"))
        {
            Running(true);
        }
        else { Running(false); }
    }
    void Running(bool run)
    {
        anim.SetBool("run", run);
        if(run == true && inputV == 1 && inputH == 0)
        {
            speedIncrease = 2.5f;
        }else
        {
            speedIncrease = 1;
        }
    }



    void CanRoll()
    {
        if (Input.GetButtonDown("roll"))
        {
            Rolling(true);
        }
        else { Rolling(false); }
    }
    void Rolling(bool roll)
    {
        anim.SetBool("roll", roll);
    }
}
