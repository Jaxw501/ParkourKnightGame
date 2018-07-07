using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDirectional : MonoBehaviour {
    public Animator anim;
    private float inputV;
    private float inputH;


	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Walking();
    }
    void Walking()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
    }
}
