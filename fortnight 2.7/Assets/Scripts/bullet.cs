using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed;
    public float destroy_time;
    public float damage;

    private Vector2 direction;
    private Vector2 startingPosition;
	
    // Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        startingPosition = this.transform.position;
        direction = transform.right;
        rb2d.AddForce(direction * speed);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate () {
        Destroy(this.gameObject, destroy_time);
        //rb2d.AddForce(direction * speed * Time.deltaTime);
        //rb2d.AddForce(transform.x * speed * Time.deltaTime);
        //if ((Math.Abs(this.transform.position.y - startingPosition.y) + Math.Abs(this.transform.position.x - startingPosition.x)) >= distance) {
        //    Destroy(GameObject bullet);
        //}

    }
}
