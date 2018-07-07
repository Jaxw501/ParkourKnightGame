using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    public float radius = 3f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public static bool interactionCanHappen = false;
    public static InteractableObject interact;


    void OnMouseOver()
    {
        InteractableObject interactable = PlayerCasting.hit.collider.GetComponent<InteractableObject>();
        interact = interactable;
        if (interactable != null)
        {
            print("not null");
            interactionCanHappen = true;

        }
        else
        {
            print("null");
            interactionCanHappen = false;
        }
    }
    void OnMouseExit()
    {
        interactionCanHappen = false;
    }
}
