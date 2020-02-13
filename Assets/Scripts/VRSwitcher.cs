using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSwitcher : MonoBehaviour
{
    public GameObject knifeVR;
    public GameObject harpoonGunVR;
    public GameObject playerVR;
    public GameObject playerPC;
    void Start()
    {
        if (OptionsKeeper.instance.vrEnabled == true) //Actives and deactivates certain items based on whether the player is playing VR or not.
        {
            knifeVR.SetActive(true);
            harpoonGunVR.SetActive(true);
            playerVR.SetActive(true);
            playerPC.SetActive(false);
        }
        else if (OptionsKeeper.instance.vrEnabled == false)
        {
            knifeVR.SetActive(false);
            harpoonGunVR.SetActive(false);
            playerVR.SetActive(false);
            playerPC.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
