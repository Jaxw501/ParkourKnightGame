
using UnityEngine;

public class LevelFinish : MonoBehaviour {
    public GameObject Green1;
    public GameObject Green2;
    public GameObject Green3;
    public GameObject Grey1;
    public GameObject Grey2;
    public GameObject Grey3;
    public GameObject EndText;
    public int gemCollected = 0;
    public bool FinishGame = false;

    void Start()
    {
        MaxProgress();
    }
    void Update()
    {
        if(gemCollected != Gem.GemCollected)
        {
            gemCollected = Gem.GemCollected;
            LvlComplete();
            Progress();
            if (FinishGame == true)
            {
                EndText.SetActive(true);
            }
        }
    }

    public void LvlComplete()
    {
        if (gemCollected == GameStats.NumOfGems)
        {
            FinishGame = true;
            EndText.SetActive(true);
        }
    }
    public void MaxProgress()
    {
        int ProgressPip = GameStats.NumOfGems;
        if (ProgressPip >= 1)
        {
            Grey1.SetActive(true);
        }

        if (ProgressPip >= 2)
        {
            Grey2.SetActive(true);
        }

        if (ProgressPip >= 3)
        {
            Grey3.SetActive(true);
        }

    }
    public void Progress()
    { 
        if (gemCollected >= 1)
        {
            Green1.SetActive(true);
        }

        if (gemCollected >= 2)
        {
            Green2.SetActive(true);
        }
        if (gemCollected >= 3)
        {
            Green3.SetActive(true);
        }

    }
}
