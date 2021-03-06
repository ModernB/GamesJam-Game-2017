﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    bool hitPlayer = false;
    bool canGo = false;
    public float speed;
    public Player p;
    public int hopForce;
    Rigidbody rb;
    Vector3 spawn;

    private void Start()
    {
        spawn = this.transform.position;

    }


    void Update ()
    {
        if (!hitPlayer && canGo)
        {
            
           transform.Translate(Vector3.right * speed * Time.deltaTime);
           
           
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitPlayer = true;
            Debug.Log("Hit PLayer!");
        }
    }

  

    public void ResetPostion()
    {
        hitPlayer = false;
        canGo = false;
        this.transform.position = spawn;

    }

    public void canGoNow()
    {
        canGo = true;
    }



}
