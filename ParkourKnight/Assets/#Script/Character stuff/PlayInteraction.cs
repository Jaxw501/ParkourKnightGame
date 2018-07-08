using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInteraction : MonoBehaviour
{
    // pop ups saying how to lock on/off
    public GameObject LockOnPrompt;
    public GameObject LockOffPrompt;

    // used in other scripts, for whether character has a focus or not
    public static bool Focussing;
    // used in other scripts, for what the character is focussing on
    public static InteractableObject FocussingOn = null;

    // used in this script, for whether character has a focus or not
    public InteractableObject focus;

    void Update()
    {
        if (Focussing == true)
        {
            if (FocussingOn.Enemy == true)
            {

                if (Input.GetButtonDown("Action"))
                {
                    RemoveFocus();
                    LockOffPrompt.SetActive(false);
                }
            }
        }
        

        if (InteractableObject.interactionCanHappen == true 
            && InteractableObject.isEnemy == true)
        {
            if (focus == null)
            {
                if(PlayerCasting.DistFromTarget < 20)
                {
                    LockOffPrompt.SetActive(false);
                    LockOnPrompt.SetActive(true);

                    if (Input.GetButtonDown("Action"))
                    {
                        SetFocus(InteractableObject.Object);
                        LockOnPrompt.SetActive(false);
                    }
                } else { LockOffPrompt.SetActive(false); }
                
            }


            else
            {
                if (Input.GetButtonDown("Action"))
                {
                    RemoveFocus();
                    LockOffPrompt.SetActive(false);
                }
            }
        }

        else LockOnPrompt.SetActive(false);

    }
    void SetFocus(InteractableObject newFocus)
    {
        focus = newFocus;
        LockOffPrompt.SetActive(true);
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