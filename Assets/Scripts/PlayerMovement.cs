#pragma warning disable CS0618 // Typ nebo člen je zastaralý.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody player;
    ParticleSystem trail;

	public float speed = 10;


    public float pitch = 0;
    public float yaw = 0;
    public float roll = 0;
    float vel = 0;

 
    Vector3 movement;

    public float sens = 1.323232f;

    void Start () 
	{
		player = GetComponent<Rigidbody>();
        trail = GetComponentInChildren<ParticleSystem>();
        Vector3 currentRot = player.transform.position;
    }

	void FixedUpdate () 
	{
        // get inputs
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Horizontal");
        roll = Input.GetAxis ("Roll");
		vel = Input.GetAxis ("Vertical");
        
        // controlling pitch
        player.AddTorque(transform.right * pitch * (sens / 2));

        // controlling yaw
        player.AddTorque(transform.up * yaw * (sens / 2));

        // controlling roll        
        player.AddTorque(transform.forward * roll * (sens / 2));

        // move forwards & backwards
        movement = new Vector3(0, 0, vel);
        player.AddForce(player.rotation * movement * speed / Time.deltaTime);

        if (player.velocity.magnitude > speed)
        {
            player.velocity = player.velocity.normalized * speed;
        }

        // controlling the engine trail
        if (player.velocity.magnitude >= 0.03 && vel < 0)
        {
            trail.enableEmission = false;
        }
        else if (player.velocity.magnitude >= 0.01 && vel >= 0)
        {
            trail.enableEmission = true;
        }

        //controlling planet freeze WIP
    }
}
