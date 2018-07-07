using UnityEngine;

public class Interactables : MonoBehaviour
{

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
