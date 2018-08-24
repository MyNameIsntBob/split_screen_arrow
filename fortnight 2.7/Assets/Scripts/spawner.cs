using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public GameObject player;

    private bool player_dead;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        player_dead = false;
    }

    // private void InvokeRepeating(string v, float spawnTime1, float spawnTime2)
    //{
    //   throw new NotImplementedException();
    //}

    // Update is called once per frame
    private void Update()
    {
        if (player == null)
        {
            player_dead = true;
        }

    }

    void Spawn()
    {

        if (player_dead == false)
        { 
            int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

    }
}