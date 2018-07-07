
using UnityEngine;

public class Gem : MonoBehaviour {

    public int RotateSpeed;
    public static int GemCollected = 0;
    public AudioSource GemCollectSound;
    public GameObject ThisGem;


    // Update is called once per frame
    void Update () {
        transform.Rotate(0, RotateSpeed, 0, Space.World);
	}
    void OnTriggerEnter(Collider other)
    {
        GemCollectSound.Play();
        ThisGem.SetActive(false);

    }
}
