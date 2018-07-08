using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public float radius = 5f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public static bool interactionCanHappen = false;
    public static InteractableObject interact;
    public bool Enemy = false;
    public static bool isEnemy;


    void Start()
    {
        
    }
    void OnMouseOver()
    {
        InteractableObject interactable = PlayerCasting.hit.collider.GetComponent<InteractableObject>();
        interact = interactable;
        if (interactable != null)
        {
            isEnemy = interactable.Enemy;
            interactionCanHappen = true;
        }
        else
        {
            interactionCanHappen = false;
        }
    }
    void OnMouseExit()
    {
        interactionCanHappen = false;
    }
}