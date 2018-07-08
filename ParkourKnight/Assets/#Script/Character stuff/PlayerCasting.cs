
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    // autological (self explanitory)
    public static float DistFromTarget;
    public float DistToTarget;

    // stores the thing that is hit by the beam
    public static RaycastHit hit;

    // the location of the thing that is hit with the beam
    public static Transform target;
    
    

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        // shoots beam forward, if there's an object, it's stored as Hit 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            DistToTarget = Hit.distance;
            DistFromTarget = Hit.distance;
            hit = Hit;
            target = Hit.collider.GetComponent<Transform>();
        }
    }
}
