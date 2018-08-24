using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


    public float health;
    public float armor = 0.1f;
    //armor should be between 0 and 1
    //public Transform player_pos;
    public float sight;
    public float run_speed;
    public float walk_speed;
    public float chase_time;
    public float enemy_damage;
    public float wander_time;

    private float speed_randomizer;
    private Transform player_pos;
    private Rigidbody2D rb2d;
    private float counter;
    private Transform my_pos;
    private float speed;
    private float current_health;
    private bool wander;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        current_health = health;
        wander = true;
        speed = walk_speed;
        counter = wander_time;
        player_pos = GameObject.FindWithTag("Player").transform;
        speed_randomizer = UnityEngine.Random.Range(0.5f, 1.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //var collisiontype = collision.GetType();
        //const char V = 'bullet';

        //bullet.

        if (collision.gameObject.tag == "bullet")
        {
            bullet bullet = collision.gameObject.GetComponent<bullet>();
            current_health -= (bullet.damage * (1 - armor));
            wander = false;
        }

        //SpeedController speedController = go.GetComponent<SpeedController>();
        //float courrentSpeed = speedController.speed;
    }


    // Update is called once per frame
    private void FixedUpdate () {
        my_pos = this.transform;
        if (current_health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (player_pos != null)
        {

        
            if (Math.Abs(player_pos.position.y - my_pos.position.y) + Math.Abs(player_pos.position.x - my_pos.position.x) <= sight)
            {
                wander = false;
                counter = 0;
            }
            else if (wander == false)
            {
                if (counter <= chase_time)
                {
                    counter += Time.deltaTime;
                }
                else
                {
                    wander = true;
                }

            }
        }
        else
        {
            wander = true;
        }
        
        



        if (wander == true)
        {
            speed = walk_speed * speed_randomizer;
            if (counter <= wander_time)
            {
                transform.position += transform.right * speed * Time.deltaTime;
                counter += Time.deltaTime;
            }
            else
            {
                var ran = UnityEngine.Random.value;
                rb2d.transform.Rotate(new Vector3(0, 0, Mathf.Atan(ran) * Mathf.Rad2Deg));
                counter = 0;
            }

        }
        else
        {
            speed = run_speed * speed_randomizer;

            var objectPos = this.transform.position;
            var dir = player_pos.position - objectPos;
            rb2d.transform.rotation = Quaternion.Euler(euler: new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));



            //transform.LookAt(player_pos);
            transform.position += transform.right * speed * Time.deltaTime;
            counter = wander_time;
        }
	}
}
