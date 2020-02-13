using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDiverBehaviour : MonoBehaviour
{
    int health;
    bool isDead;
    bool runOnce;
    int randomSound;
    float despawnTimer;
    float gruntTimer;
    GameObject target;
    NavMeshAgent nma;
    Animator ani;
    Rigidbody[] rigRigidbodies;
    public AudioClip hit;
    public AudioClip grunt1;
    public AudioClip grunt2;
    public AudioClip dead;
    AudioSource aud;

    public Collider head;
    public Collider body;

    void Start()
    {
        health = 100;
        isDead = false;
        runOnce = false;
        randomSound = 0;
        despawnTimer = 10f;
        gruntTimer = 3f;
        nma = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        rigRigidbodies = GetComponentsInChildren<Rigidbody>();
        aud = GetComponent<AudioSource>();
        if (OptionsKeeper.instance.vrEnabled == true) //Changes player target based on whether the player is playing VR or not.
        {
            target = GameObject.Find("Player/SteamVRObjects/VRCamera");
        }
        else if (OptionsKeeper.instance.vrEnabled == false)
        {
            target = GameObject.Find("PlayerPC");
        }
    }

    void Update()
    {
        gruntTimer -= Time.deltaTime;

        if (gruntTimer <= 0)
        {
            randomSound = Random.Range(0, 6);
            if (randomSound <= 3)
            {
                aud.clip = grunt1;
            }

            if (randomSound >= 3)
            {
                aud.clip = grunt2;
            }

            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            gruntTimer = Random.Range(5f, 7f);
        }

        if (health <= 0)
        {
            isDead = true;
        }

        if (isDead == false)
        {
            nma.SetDestination(target.transform.position);
        }

        if (isDead == true)
        {

            foreach (Rigidbody rb in rigRigidbodies) //Makes every rigidbody kinematic and adds a velocity so that it falls slowly.
            {
                rb.isKinematic = false;
                rb.velocity = new Vector3(0, -0.5f, 0.5f);
            }

            if (runOnce == false)
            {
                gameObject.tag = "Untagged";
                aud.clip = dead;
                aud.pitch = Random.Range(0.8f, 1.2f);
                aud.Play();

                ani.enabled = false;
                Destroy(head);
                Destroy(body);
                Destroy(nma);
                runOnce = true;
            }

            despawnTimer -= Time.deltaTime;

            if (despawnTimer <= 0)
            {
                Destroy(gameObject);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Harpoon")
        {
            health -= 50;
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.clip = hit;
            aud.Play();
            ScoreKeeper.instance.AddScore(100);  
        }

        if (other.gameObject.tag == "Knife")
        {
            health -= 100;
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.clip = hit;
            aud.Play();
            ScoreKeeper.instance.AddScore(200);
        }
    }

}
