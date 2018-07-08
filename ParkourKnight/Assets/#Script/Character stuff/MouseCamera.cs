using UnityEngine;

public class MouseCamera : MonoBehaviour
{

    //
    public GameObject Crosshair;
    // will be 1 or 0
    public int CanTurn;

    // sensitivity
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    // shows pitch/yaw for troubleshooting
    public static float currentPitch;
    public static float currentYaw;

    // used for camera direction
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        CameraControl(1f);
        if(PlayInteraction.Focussing == true)
        {
            if (PlayInteraction.FocussingOn.Enemy == true)
            {
                Crosshair.SetActive(false);
            }
            else { Crosshair.SetActive(true); }
        }
        else { Crosshair.SetActive(true);}
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
