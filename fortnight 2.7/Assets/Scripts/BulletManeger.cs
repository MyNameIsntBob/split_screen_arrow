using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManeger : MonoBehaviour
{


    //public Transform bulletSpawn;
    public GameObject prefab;
    public float spacer = 3.5f;
    private float spacercounter = 0.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spacercounter < spacer)
        {
            spacercounter += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && spacercounter >= spacer)
        {

            spacercounter = 0.0f;
            // Create the Bullet from the Bullet Prefab
            GameObject bullet = (GameObject)Instantiate(
                prefab,
                this.transform.position,
                this.transform.rotation);
            bullet bscript = bullet.GetComponent<bullet>();
            //bscript.setPlayer(transform.parent.tag);

            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());


            // Add velocity to the bullet
            //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            // Destroy the bullet after 2 seconds
            //Destroy(bullet, destroytime);



        }

    }
}

