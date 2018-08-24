using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 100;
    public float dodgedistance = 10;
    public float dodgetimer = 5;
    public float armor;
    public float health;
    public bool dead;
    public float invincible_time;
    public float nock_back;

    //private bool wallcollide;
    private float in_time_counter;
    private float current_health;
    private float dodgecounter = 0;
    private float multiplyer;
    private bool targetable = true;
    //private Vector2 nockback;

    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        current_health = health;
        dead = false;
        in_time_counter = invincible_time;
	}

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && in_time_counter >= invincible_time)
        {
            enemy enemy = collision.gameObject.GetComponent<enemy>();
            current_health -= (enemy.enemy_damage * (1 - armor));
            Vector2 nockback = new Vector2(-enemy.transform.position.x, -enemy.transform.position.y);
            rb2d.velocity = (nockback * nock_back);
            in_time_counter = 0;
        }
        if (collision.gameObject.tag == "bullet")
        {
            takeDamage(1);
            print("ouch");
        }
    }


    private void Update()
    {
        if (current_health <= 0)
        {
            dead = true;
            //    Time.timeScale = 0;
            Destroy(this.gameObject, 1f);
        }

    }

    void FixedUpdate () {

        //print(current_health);
        if (in_time_counter <= invincible_time)
        {
            in_time_counter += Time.deltaTime;
        }

        //if (current_health <= 0)
        //{
        //    dead = true;
        //    //    Time.timeScale = 0;
        //    Destroy(this.gameObject, 1f);
        //}

        //if (dead == true)
        //{
        //    Time.timeScale = 0;
        //    return;
        //}



        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - objectPos;
        rb2d.transform.rotation = Quaternion.Euler(euler: new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));


        float moveHorizontal= Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * Time.deltaTime;

        rb2d.velocity = (movement * speed);

        if (dodgecounter < dodgetimer)
        {
            dodgecounter += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Math.Abs(movement.y) + Math.Abs(movement.x) != 0 && dodgecounter >= dodgetimer)
        {
            multiplyer = 1f;
            if (movement.x != 0 && movement.y != 0)
            {
                multiplyer = 0.5f;
            }
            Vector2 new_movement = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
            rb2d.transform.position = new Vector2(this.transform.position.x + (new_movement.x * dodgedistance * multiplyer), this.transform.position.y + (new_movement.y * dodgedistance * multiplyer));
            //rb2d.velocity = Vector2.Lerp(this.transform.position, new_movement * dodgedistance * multiplyer, 1);
            dodgecounter = 0;
        }
	}

    public void takeDamage(int damage)
    {
        current_health -= damage;
    }

    /*
    private void Dodge(float rollspeed, float distance)
    {
        float distanceDodged = 0;
        Vector2 startingPosition = this.transform.position;
        bool keepDodging = true;
        Vector2 movement = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        counter = 0;
        wallcollide = false;
        
        while (distanceDodged < distance && keepDodging) {
            
            distanceDodged = (this.transform.position.x - startingPosition.x) + (this.transform.position.y - startingPosition.y);
            print("distance dodged: " + distanceDodged + " - current position: " + this.transform.position + " - starting position: " + startingPosition);



            if (wallcollide)
            {
                keepDodging = false;
            }


            rb2d.velocity = Vector2.Lerp(startingPosition, movement * rollspeed, rollspeed);
                //(movement * rollspeed);

            
            if (counter > 100)
            {
                //print("the distance dodged: " + distanceDodged + " distance need to dodge: " + distance );
                keepDodging = false;
                break;
            }
            
            counter += 1;
            //Player.SetHorizontalSpeed(speed);

            //yeild return 0;
        }
        //print("ending position" + this.transform.position);

        //Player.State = PlayerState.Idle;
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if 
    }
    */
}
