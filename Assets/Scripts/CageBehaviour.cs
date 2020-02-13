using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CageBehaviour : MonoBehaviour
{

    int health;
    float damageCooldown;
    AudioSource aud;
    public GameObject part1; //Could put this in a list probably.
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
    public GameObject part7;
    public GameObject part8;
    public GameObject part9;
    public GameObject part10;
    public GameObject part11;

    void Start()
    {
        health = 100;
        damageCooldown = 2f;
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        damageCooldown -= Time.deltaTime;

        if (health <= 91 && part1 != null) //Removes part of the cage on damage.
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part1);
        }

        if (health <= 82 && part2 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part2);
        }

        if (health <= 73 && part3 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part3);
        }

        if (health <= 64 && part4 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part4);
        }

        if (health <= 55 && part5 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part5);
        }

        if (health <= 46 && part6 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part6);
        }

        if (health <= 37 && part7 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part7);
        }

        if (health <= 28 && part8 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part8);
        }

        if (health <= 19 && part9 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part9);
        }

        if (health <= 10 && part10 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part10);
        }

        if (health <= 5 && part11 != null)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
            GameObject.Destroy(part11);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            health -= 1;
        }

        if (collision.gameObject.tag == "Shark")
        {
            if (damageCooldown <= 0f)
            {
                health -= 5;
                damageCooldown = 2f;
            }
        }
    }

}
