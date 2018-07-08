﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInteraction : MonoBehaviour
{
    public GameObject ActionPrompt;
    public static bool Focussing;
    public static InteractableObject FocussingOn = null;
    public GameObject DeactionPrompt;
    public InteractableObject focus;
    void Update()
    {
        if (Focussing == true)
        {
            if (FocussingOn.Enemy == true)
            {

            }
        }
        

        if (InteractableObject.interactionCanHappen == true 
            && InteractableObject.isEnemy == true)
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
        else if (focus != null 
            && InteractableObject.interactionCanHappen == false 
            && InteractableObject.isEnemy == true)
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
        FocussingOn = null;

    }
}