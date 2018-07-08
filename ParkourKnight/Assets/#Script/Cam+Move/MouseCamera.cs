using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float currentPitch;
    public float currentYaw;


    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {

        if (PlayInteraction.Focussing == false)
        {
            CameraControl(1f);
        }
        else if (PlayInteraction.Focussing == true)
        {
            if (PlayInteraction.FocussingOn.Enemy == false)
            {

                CameraControl(0f);

            }


        }
    }
    void CameraControl(float CanTurn)
    {
        Cursor.lockState = CursorLockMode.Locked;
        pitch -= speedV * Input.GetAxis("Mouse Y") * Time.deltaTime * 40 * CanTurn;
        yaw += speedH * Input.GetAxis("Mouse X") * Time.deltaTime * 40 * CanTurn;
        currentPitch = pitch;
        currentYaw = yaw;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
