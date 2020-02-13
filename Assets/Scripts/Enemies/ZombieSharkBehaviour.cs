using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSharkBehaviour : MonoBehaviour
{
    PathCreation.Examples.PathFollower pathSet;
    GameObject playerTarget;
    GameObject otherTarget;
    NavMeshAgent nma;
    Animator ani;
    Rigidbody rb;
    AudioSource hit;
    float despawnTimer;
    public bool attackingCage;
    bool isDead;
    int sharkPath;
    int health;
    public float attackTimer;

    void Start()
    {
        sharkPath = Random.Range(0, 5);
        attackTimer = Random.Range(10, 30);
        pathSet = GetComponent<PathCreation.Examples.PathFollower>();
        if (OptionsKeeper.instance.vrEnabled == true) //Changes player target based on whether the player is playing VR or not.
        {
            playerTarget = GameObject.Find("Player/SteamVRObjects/VRCamera");
        }
        else if (OptionsKeeper.instance.vrEnabled == false)
        {
            playerTarget = GameObject.Find("PlayerPC");
        }
        nma = GetComponentInParent<NavMeshAgent>();
        nma.enabled = false;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        hit = GetComponent<AudioSource>();
        despawnTimer = 10f;
        attackingCage = false;
        isDead = false;
        health = 100;
        pathSet.SetPath(sharkPath);
        pathSet.SetSpeed(1);
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;

        if (health <= 0)
        {
            isDead = true;
        }

        if (attackTimer <= 0)
        {
            AttackCage();
        }
        if (isDead == false)
        {
            if (attackingCage == true)
            {

                pathSet.enabled = false; //Disables the path when the shark is attacking the cage.
                nma.enabled = true;
                nma.SetDestination(playerTarget.transform.position);
                transform.LookAt(playerTarget.transform);
            }
        }

        if (isDead == true)
        {
            nma.enabled = false; //Disables the NavMeshAgent on it's dead.
            pathSet.enabled = false;
            ani.enabled = false;
            rb.isKinematic = false;
            rb.velocity = new Vector3(0, -0.1f, 0.1f);
            gameObject.tag = "Untagged";

            despawnTimer -= Time.deltaTime;

            if (despawnTimer <= 0) //Despawns the object after 10 seconds.
            {
                Destroy(gameObject);
            }

        }

        void AttackCage()
        {
            attackingCage = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Harpoon")
        {
            health -= 20;
            hit.Play();
            ScoreKeeper.instance.AddScore(100);
        }
    }
}