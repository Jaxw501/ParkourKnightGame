
using UnityEngine;

public class MouseCamera : MonoBehaviour {
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float currentPitch;
    public float currentYaw;


    private float yaw = 0.0f;
    private float pitch = 0.0f;
	
	// Update is called once per frame
	void Update ()
    {
        
        if(PlayInteraction.Focussing == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            pitch -= speedV * Input.GetAxis("Mouse Y") * Time.deltaTime * 40;
            yaw += speedH * wasdMovement.XAxis * Time.deltaTime * 40;
            currentPitch = pitch;
            currentYaw = yaw;

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

    }
}
