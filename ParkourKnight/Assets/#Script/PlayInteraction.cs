using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInteraction : MonoBehaviour
{
    public GameObject ActionPrompt;
    public static bool Focussing = false;
    public static InteractableObject FocussingOn;
    public GameObject DeactionPrompt;
    public InteractableObject focus;
    void Update()
    {
        if (InteractableObject.interactionCanHappen == true)
        {
            if (focus == null || focus != InteractableObject.interact)
            {
                DeactionPrompt.SetActive(false);
                ActionPrompt.SetActive(true);
                if (Input.GetButtonDown("Action"))
                {
                    SetFocus(InteractableObject.interact);
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

        }
        else if (focus != null && InteractableObject.interactionCanHappen == false)
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
        FocussingOn = focus;

    }
    void RemoveFocus()
    {
        focus = null;
        Focussing = false;

    }
}