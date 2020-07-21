using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip playerSelect, playerClear, playerSwap;
    static AudioSource audioSource;
       void Start()
    {
        playerClear = Resources.Load<AudioClip>("Clear");
        playerSelect = Resources.Load<AudioClip>("Select");
        playerSwap = Resources.Load<AudioClip>("Swap");

        audioSource = GetComponent<AudioSource>();
    }

       void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "Clear":
                audioSource.PlayOneShot(playerClear);
                break;
            case "Select":
                audioSource.PlayOneShot(playerSelect);
                break;
            case "Swap":
                audioSource.PlayOneShot(playerSwap);
                break;

        }
    }
}
