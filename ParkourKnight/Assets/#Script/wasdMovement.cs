
using UnityEngine;

public class wasdMovement : MonoBehaviour {
    private string adInputAxis = "Horizontal";
    private string wsInputAxis = "Vertical";
    public float speedH = 2.0f;
    public static float XAxis;


    private float yaw = 0.0f;


    public float moveSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        float adAxis = Input.GetAxis(adInputAxis);
        float wsAxis = Input.GetAxis(wsInputAxis);
        ApplyInput(adAxis, wsAxis);

        //if(PlayInteraction.Focussing == false)
        //{
        yaw += speedH * Input.GetAxis("Mouse X") * Time.deltaTime * 40;
        XAxis = Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        //}

    }
    private void ApplyInput(float adInput, float wsInput)
    {
        ad(adInput);
        ws(wsInput);
    }

    private void ad(float input)
    {
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime);
    }
    private void ws(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime);
    }
}
