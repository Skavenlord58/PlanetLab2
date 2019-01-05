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
    float currentRotPitch;
    float currentRotYaw;
    float currentRotRoll;

    Quaternion targetRotationPitch = new Quaternion();
    Quaternion targetRotationYaw = new Quaternion();
    Quaternion targetRotationRoll = new Quaternion();

    public float sens = 1.323232f;

    void Start () 
	{
		player = GetComponent<Rigidbody>();
        trail = GetComponentInChildren<ParticleSystem>();
        Vector3 currentRot = player.transform.position;
    }

	// Update is called once per frame
	void FixedUpdate () 
	{
		roll = Input.GetAxis ("Roll");
		vel = Input.GetAxis ("Vertical");
        yaw = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Pitch");

        //yaw
        currentRotYaw += yaw * sens;
        targetRotationYaw = Quaternion.AngleAxis(currentRotYaw, Vector3.up);	
        player.rotation = Quaternion.Slerp(player.rotation, targetRotationYaw, Time.deltaTime * 2.0f);

        //pitch
        currentRotPitch += pitch * sens;
        targetRotationPitch = Quaternion.AngleAxis(currentRotPitch, Vector3.right);
        player.rotation = Quaternion.Slerp(player.rotation, targetRotationPitch, Time.deltaTime * 2.0f);

        //roll
        currentRotRoll += roll * sens;
        targetRotationRoll = Quaternion.AngleAxis(currentRotRoll, Vector3.back);
        player.rotation = Quaternion.Slerp(player.rotation, targetRotationRoll, Time.deltaTime * 2.0f);

        //move forwards & backwards
        movement = new Vector3(0, 0, vel);
        player.AddForce(player.rotation * movement * speed / Time.deltaTime);

		if (player.velocity.magnitude > speed)
		{
			player.velocity = player.velocity.normalized * speed;
		}
        
        //controlling the engine trail
        if (player.velocity.magnitude >= 0.03 && vel < 0)
        {
            trail.enableEmission = false;
        }
        else if (player.velocity.magnitude >= 0.01 && vel >= 0)
        {
            trail.enableEmission = true;
        }
    }
}
