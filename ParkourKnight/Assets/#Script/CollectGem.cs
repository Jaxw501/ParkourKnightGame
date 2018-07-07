using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGem : MonoBehaviour
{
    public float TheDistance;
    public static int GemCollected = 0;
    public GameObject ActionPrompt;
    public GameObject ActionDisplay;
    public AudioSource CollectSound;
    public GameObject ThisGem;

    // Update is called once per frame
    void Update () {
        TheDistance = PlayerCasting.DistFromTarget;	
	}

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionPrompt.SetActive(true);
            ActionDisplay.SetActive(true);

        }
        else
        {
            ActionPrompt.SetActive(false);
            ActionDisplay.SetActive(false);
        }
        if (Input.GetButtonDown("GetGem"))
        {
            if (TheDistance <= 3)
            {
                ThisGem.SetActive(false);
                CollectSound.Play();
                ActionPrompt.SetActive(false);
                ActionDisplay.SetActive(false);
                GemCollected++;
            }
        }
    }
    void OnMouseExit()
    {
        ActionPrompt.SetActive(false);
        ActionDisplay.SetActive(false);
    }

}
