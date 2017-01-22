﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health;
    public float currentVelocity;
    public int speed;
    public float jumpForce;
    private float maxSpeed;
    public Rigidbody rb;
    enum PowerUp { None, Unicycle, Bicycle};
    PowerUp currentPowerUp;
    bool isGrounded;

    public delegate void playerAction();
    public static event playerAction GameOver, GameWon;
    Vector3 spawn;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        spawn = this.transform.position;
        currentPowerUp = PowerUp.None;
        health = 5;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Check for input by player
        currentVelocity = Input.GetAxis("Horizontal") * speed;
        currentVelocity *= Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        this.transform.Translate(currentVelocity, 0, 0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            //Start coroutine based on Obstacle's Density and SlowPlayerByTime
            Obstacle obs = collision.gameObject.GetComponent<Obstacle>();            
            Debug.Log("Density = " + obs.getDensity());
            Destroy(obs);
        }

        if (collision.gameObject.tag == "Wave")
        {
            DamagePlayer(1);
            Debug.Log("Lose");
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            //Game won, inform gamemanager
            if (GameWon != null)
            {
                GameWon();
                Debug.Log("Win!");
            }
        }

        if (other.gameObject.tag == "Wave")
        {
            Debug.Log("Game Over!");
            //Game won, inform gamemanager
            if (GameOver != null)
            {
                GameOver();
                Debug.Log("Game Over!");
            }
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            //Animate background image to next image
        }

    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void ResetPostion()
    {
        this.transform.position = spawn;
    }

    private void DamagePlayer(int x)
    {
        health -= x;
        if (health <= 0)
        {
            //game over
            if (GameOver != null)
            {
                GameOver();
            }

        }
    }

}
