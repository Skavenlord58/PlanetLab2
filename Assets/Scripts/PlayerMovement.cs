using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody player;

	public float speed = 4;


    public float pitch = 0;
    public float yaw = 0;
    public float roll = 0;

    
    float vel = 0;
    Quaternion targetRotation = new Quaternion();

    Vector3 movement;
    public Vector3 currentRotYaw;
    public Vector3 currentRotRoll;
    public Vector3 currentRotPitch;

    void Start () 
	{
		player = GetComponent<Rigidbody>();
        Vector3 currentRot = player.transform.position;
    }

	// Update is called once per frame
	void FixedUpdate () 
	{
		roll = Input.GetAxis ("Mouse X");
		vel = Input.GetAxis ("Vertical");
        yaw = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Mouse Y");

        currentRotYaw.x += (yaw);
        // if (currentRotYaw)
        
        
        //yaw
        targetRotation = Quaternion.LookRotation(currentRotYaw, Vector3.up);	
        player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * 2.0f);

        //move forwards & backwards
        movement = new Vector3(0, 0, vel);
        player.AddForce(movement * speed / Time.deltaTime);

		if (player.velocity.magnitude > 2 * speed)
		{
			player.velocity = player.velocity.normalized * 2 * speed;
		}
	}
}
