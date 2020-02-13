using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HarpoonGunBehaviour : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject harpoonPrefab;
    public GameObject harpoonPosObj;
    GameObject harpoonClone;
    ParticleSystem psHarpoonGun;
    public GameObject showDart;
    Vector3 harpoonPos;
    AudioSource shoot;
    int startAmmo = 5;
    int harpoonAmmo;
    float fireCountdown = 1f;
    Interactable interactable;

    void Start()
    {
        shoot = GetComponent<AudioSource>();
        harpoonPos = harpoonPosObj.transform.position;
        harpoonAmmo = startAmmo;
        interactable = GetComponent<Interactable>();
        psHarpoonGun = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if (harpoonAmmo >= 1)
            {
                if (fireCountdown <= 0f && fireAction[source].stateDown)
                {
                    Fire();
                }
            }
        }

        if (OptionsKeeper.instance.vrEnabled == false && fireCountdown <= 0f && Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (harpoonAmmo >= 1)
        {
            showDart.SetActive(true);
        }

        if (harpoonAmmo <= 0)
        {
            showDart.SetActive(false);
        }

        fireCountdown -= Time.deltaTime;
    }

    void Fire()
    {
        shoot.Play();
        harpoonAmmo--;
        fireCountdown = 0.3f;
        harpoonClone = Instantiate(harpoonPrefab, harpoonPos, Quaternion.identity) as GameObject;
        harpoonClone.transform.position = harpoonPosObj.transform.position;
        harpoonClone.transform.rotation = harpoonPosObj.transform.rotation;
        Physics.IgnoreCollision(harpoonClone.GetComponent<Collider>(), GetComponent<Collider>());
        psHarpoonGun.Play();
    }

    public void Reload()
    {
        harpoonAmmo = startAmmo;
    }
}