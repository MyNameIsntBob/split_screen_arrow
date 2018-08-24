using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_screen : MonoBehaviour {

    // Use this for initialization
    public bool game_pause = false;

    public bool player_dead;
    public GameObject player;

    private Transform player_pos;
    //private Transform starting_point;


	void Start () {
        Time.timeScale = 1;
        player_dead = false;
        player_pos = GameObject.FindWithTag("Player").transform;
        //starting_point.position = new Vector2(0, 0);

	}
	
	// Update is called once per frame
	void Update () {

        //player_live = GameObject.FindGameObjectWithTag("Player".player_live);
                
        //GameObject.FindGameObjectWithTag("Player");
        
        if (player_pos == null)
        {
            player_dead = true;
        }
        //player_dead = player.dead;


        
        if (player_dead == true)
        {

            Time.timeScale = 0;

            /*
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Instantiate(player, starting_point.position, starting_point.rotation);
                player_pos = GameObject.FindWithTag("Player").transform;
                player_dead = false;
                Time.timeScale = 1;
            }
            */
        }
        

        

        if (game_pause == true && player_dead == false)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Escape)){
                game_pause = false;
            }
        }
        else if (player_dead == false)
        {
            Time.timeScale = 1;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                game_pause = true;
            }

        }
	}
}
