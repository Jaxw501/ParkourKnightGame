using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInteraction : MonoBehaviour
{
    public GameObject ActionPrompt;
    public static bool Focussing = false;
    public GameObject DeactionPrompt;
    public InteractableObject focus;
    void Update()
    {
        if (Interactables.interactionCanHappen == true)
        {
            if (focus == null || focus != Interactables.interact)
            {
                DeactionPrompt.SetActive(false);
                ActionPrompt.SetActive(true);
                if (Input.GetButtonDown("Action"))
                {
                    SetFocus(Interactables.interact);
                    ActionPrompt.SetActive(false);
                }
            }


            else
            {
                if (Input.GetButtonDown("Action"))
                {
                    RemoveFocus();
                    DeactionPrompt.SetActive(false);

                }
            }
                      
        } else if(focus != null && Interactables.interactionCanHappen == false)
        {
            DeactionPrompt.SetActive(true);
            ActionPrompt.SetActive(false);
            if (Input.GetButtonDown("Action"))
            {
                RemoveFocus();
                DeactionPrompt.SetActive(false);

            }
        }
        else ActionPrompt.SetActive(false);

        

    }
    void SetFocus(InteractableObject newFocus)
    {
        focus = newFocus;
        DeactionPrompt.SetActive(true);
        Focussing = true;

    }
    void RemoveFocus()
    {
        focus = null;
        Focussing = false;

    }
}
