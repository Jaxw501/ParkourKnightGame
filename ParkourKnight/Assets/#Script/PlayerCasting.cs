
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

    public static float DistFromTarget;
    public static RaycastHit hit;
    public float DistToTarget;

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            DistToTarget = Hit.distance;
            DistFromTarget = Hit.distance;
            hit = Hit;
        }
    }
}
