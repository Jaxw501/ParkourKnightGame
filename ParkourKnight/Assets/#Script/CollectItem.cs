
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour {
    public float TheDistance;
    public GameObject ActionPrompt;
    public GameObject ActionDisplay;
    public AudioSource CollectSound;
    public GameObject ThisItem;

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
        if (Input.GetButtonDown("GetItem"))
        {
            if (TheDistance <= 3)
            {
                ThisItem.SetActive(false);
                ActionPrompt.SetActive(false);
                ActionDisplay.SetActive(false);
            }
        }
    }
    void OnMouseExit()
    {
        ActionPrompt.SetActive(false);
        ActionDisplay.SetActive(false);
    }

}
