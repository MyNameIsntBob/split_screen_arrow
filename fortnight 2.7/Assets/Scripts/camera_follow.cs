using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    // Use this for initialization
	/*
    void Start () {
		
	}
	*/

	// Update is called once per frame
	void FixedUpdate () {
        if (target != null)
        {
            Vector3 goalPos = target.position;
            goalPos.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
        }

    }
}
