﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectParticle : MonoBehaviour
{
    public int damageAmount = 1;   
    public float timeBetweenAttack = 0.5f; 
    public float burntime;
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;
    private player player_script;
    private GameObject player;
    private float lastTime=0f;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        player = GameObject.Find("player");
        player_script = player.GetComponent<player>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.name == "player"){
            if (checkTime())
                player_script.attacked(0,damageAmount);
        }
        else if ( other.gameObject.tag=="Enemy"){
            enemyBasic enemyBasic = other.gameObject.GetComponent<enemyBasic>();
            if (enemyBasic != null){
                if (checkTime())
                    enemyBasic.attacked(0,damageAmount);
            }
        }
        else{
            enemyBasic enemyBasic = other.gameObject.GetComponent<enemyBasic>();
            if (enemyBasic != null){
                if (checkTime())
                    enemyBasic.attacked(0,damageAmount);
            }
            objectStatus objectStatus = other.gameObject.GetComponent<objectStatus>();
            if (gameObject.tag == "burnp_late")
                {
                    burn(burntime);
                }
            else{
                if (objectStatus != null){
                    if (checkTime())
                        objectStatus.attackObject(damageAmount);
                }
            }
        }
    }

    // dedicated for paper
    private void burn(float burntime)
    {
        Destroy(gameObject, burntime);
        Animator paper_animation = gameObject.GetComponent<Animator>();
        paper_animation.SetBool("IsDestroy", true);
    }
    /*
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name == "player"){
            if (checkTime())
                player_script.attacked(0,damageAmount);
        }
        else if ( other.gameObject.tag=="Enemy"){
            enemyBasic enemyBasic = other.gameObject.GetComponent<enemyBasic>();
            if (enemyBasic != null){
                if (checkTime())
                    enemyBasic.attacked(0,damageAmount);
            }
        }
        else{
            enemyBasic enemyBasic = other.gameObject.GetComponent<enemyBasic>();
            if (enemyBasic != null){
                if (checkTime())
                    enemyBasic.attacked(0,damageAmount);
            }
            objectStatus objectStatus = other.gameObject.GetComponent<objectStatus>();
            if (objectStatus != null){
                if (checkTime())
                    objectStatus.attackObject(damageAmount);
            }
        }
    }*/
    bool checkTime(){
        if (Time.time - lastTime >= timeBetweenAttack){
            lastTime = Time.time;
            return true;
        }
        return false;
    }
}
