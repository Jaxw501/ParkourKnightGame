using UnityEngine;

public class wasdMovement : MonoBehaviour
{
    private string adInputAxis = "Horizontal";
    private string wsInputAxis = "Vertical";
    public float speedH = 2.0f;
    public static bool forward;
    public static bool backward;
    public static bool left;
    public static bool right;


    private float yaw = 0.0f;


    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        MovementControls(0f);

    }

    private void MovementControls(float CanTurn)
    {
        float adAxis = Input.GetAxis(adInputAxis);
        float wsAxis = Input.GetAxis(wsInputAxis);
        ApplyInput(adAxis, wsAxis);


        yaw += speedH * Input.GetAxis("Mouse X") * Time.deltaTime * 40;
        if (PlayInteraction.Focussing == false)
        {
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }

    }

    private void ApplyInput(float adInput, float wsInput)
    {
        ad(adInput);
        ws(wsInput);
    }

    private void ad(float input)
    {
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime * 1f);
    }
    private void ws(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime *RunDirectional.speedIncrease);
        if (input > 0)
        {
            forward = true;
            backward = false;
        }
        else if (input < 0)
        {
            backward = true;
            forward = false;
        }
        else
        {
            backward = false;
            forward = false;
        }
    }

}
