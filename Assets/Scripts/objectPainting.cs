﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPainting : MonoBehaviour
{
    //bomb explodes when touching the enemy or ground
    public float radius = 3f;
    private objectScript objectScript;
    public GameObject teleporting_start;
    private GameObject cur_teleporting_start;
    private player player_script;
    private GameObject player;
    public static Vector3 TeleportingGate;
    public static bool onGround = false;
    public Animator animator_painting;
    // Start is called before the first frame update
    void Start()
    {
        objectScript = new objectScript(gameObject);
        player = GameObject.Find("player");
        player_script = player.GetComponent<player>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag== "Ground"){
            cur_teleporting_start = Instantiate(teleporting_start, player_script.throwStart, Quaternion.identity);
        animator_painting.SetBool("IsGround", true);
        onGround = true;
        Destroy(gameObject, 5.0f);
        Destroy(cur_teleporting_start,5.0f);
        }
    }

    void Update(){
        TeleportingGate = cur_teleporting_start.transform.position;
    }
    
}
