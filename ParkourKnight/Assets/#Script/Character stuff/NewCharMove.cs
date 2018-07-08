using UnityEngine;

public class NewCharMove : MonoBehaviour
{ 
    public float speedH = 2.0f;
    private float yaw = 0.0f;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        MovementControls();
    }
    private void MovementControls()
    {
        yaw += speedH * Input.GetAxis("Mouse X") * Time.deltaTime * 40;
        if (PlayInteraction.Focussing == false)
        {
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
    }
}

