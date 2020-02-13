using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonBehaviour : MonoBehaviour
{
    public bool hitSomething;
    int harpoonSpeed;
    Rigidbody rbHarpoon;
    Collider clHarpoon;
    ParticleSystem psHarpoon;
    float despawnTimer;
    void Start()
    {
        hitSomething = false;
        harpoonSpeed = 10;
        despawnTimer = 10f;
        rbHarpoon = GetComponent<Rigidbody>();
        clHarpoon = GetComponent<Collider>();
        psHarpoon = GetComponent<ParticleSystem>();
    }

    void Update()
    {

        despawnTimer -= Time.deltaTime;

        if (hitSomething == false)
        {
            transform.Translate(0, 0, harpoonSpeed * Time.deltaTime);
        }

        if (hitSomething == true)
        {
            Destroy(psHarpoon);
            Destroy(rbHarpoon);
            Destroy(clHarpoon);
        }

        if (despawnTimer <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HarpoonGun")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

        if (collision.gameObject.tag == "Harpoon")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Cage" && collision.gameObject.tag != "Floor")
        {
            hitSomething = true;
            transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Cage")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

    }

}
