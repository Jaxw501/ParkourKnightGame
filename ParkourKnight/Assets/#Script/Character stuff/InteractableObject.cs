using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // used elsewhere, whether the object hit by beam in PlayerCasting is an InteractableObject
    public static bool interactionCanHappen = false;

    public static InteractableObject Object;
    // whether the object is an enemy 
    public bool Enemy = false;
    public static bool isEnemy;
    // area player must be in when locked on if enemy
    public float radius = 15f;

    //
    public bool Item = false;
    //
    public static bool isItem;


    // creates a sphere around the object when in editor mode
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // checks if the object can be interacted with
    void OnMouseOver()
    {
        InteractableObject interactable = PlayerCasting.hit.collider.GetComponent<InteractableObject>();
        Object = interactable;
        if (interactable != null)
        {
            // sets isEnemy as true or false for use in other scripts
            isEnemy = interactable.Enemy;
            // sets isItem as true or false for use in other scripts
            isItem = interactable.Item;
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