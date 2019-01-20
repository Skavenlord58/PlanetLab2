#pragma warning disable CS0618 // Typ nebo člen je zastaralý.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody player;
    ParticleSystem trail;

    public float accel = 0.3f;
    public float maxAccel = 2.6f;
    public static float speed = 400;


    public float pitch = 0;
    public float yaw = 0;
    public float roll = 0;
    float vel = 0;

    public Camera cam;
    Vector3 movement;

    public float sens = 1.323232f;

    void Start () 
	{
		player = GetComponent<Rigidbody>();
        trail = GetComponentInChildren<ParticleSystem>();
        Vector3 currentRot = player.transform.position;
        player.inertiaTensor = Vector3.one;
    }

    void Stage(int stage)
    {
        if (stage == 0)
        {
            accel = 0.3f;
            if (CameraFollow.speedmult < 1.0f && vel > 0.5f)
                CameraFollow.speedmult += 0.005f;
            else if (CameraFollow.speedmult > 1.0f)
                CameraFollow.speedmult -= 0.005f;

        }
        if (stage == 1)
        {
            accel = 0.6f;
            if (CameraFollow.speedmult < 1.3f && vel > 0.5f)
                CameraFollow.speedmult += 0.005f;
            else if (CameraFollow.speedmult > 1.3f)
                CameraFollow.speedmult -= 0.005f;
        }
        if (stage == 2)
        {
            accel = 0.9f;
            if (CameraFollow.speedmult < 1.6f && vel > 0.5f)
                CameraFollow.speedmult += 0.005f;
            else if (CameraFollow.speedmult > 1.6f)
                CameraFollow.speedmult -= 0.01f;
        }
        if (stage == 3)
        {
            accel = 1.2f;
            if (CameraFollow.speedmult < 1.9f && vel > 0.5f)
                CameraFollow.speedmult += 0.005f;
            else if (CameraFollow.speedmult > 1.9f)
                CameraFollow.speedmult -= 0.01f;
        }
        if (stage == 4)
        {
            accel = 1.6f;
            if (CameraFollow.speedmult < 2.2f && vel > 0.5f)
                CameraFollow.speedmult += 0.005f;
            else if (CameraFollow.speedmult > 2.2f)
                CameraFollow.speedmult -= 0.015f;
        }
        if (stage == 5)
        {
            accel = maxAccel;
            if (CameraFollow.speedmult < 3f && vel > 0.5f)
                CameraFollow.speedmult += 0.005f;
            else if (CameraFollow.speedmult > 3f)
                CameraFollow.speedmult -= 0.015f;
        }

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

        // making acceleration curve
        if (player.velocity.magnitude < 15)
            Stage(0);
        if (player.velocity.magnitude > 15 && player.velocity.magnitude < 44)
            Stage(1);
        if (player.velocity.magnitude > 44 && player.velocity.magnitude < 71)
            Stage(2);
        if (player.velocity.magnitude > 71 && player.velocity.magnitude < 98)
            Stage(3);
        if (player.velocity.magnitude > 98 && player.velocity.magnitude < 131)
            Stage(4);
        if (player.velocity.magnitude > 131)
            Stage(5);
            


        // accelerating
        if (vel >= 0)
            player.AddForce(player.rotation * movement * accel / Time.deltaTime);
        else
            player.AddForce(player.rotation * movement * (accel/3) / Time.deltaTime);

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

        //scanner
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out hit))
        {
            ReticleBehaviour.scannerFlag = true;
            ScannerBehaviour.Scan(hit.collider.name.ToString());
        }
        else
        {
            ReticleBehaviour.scannerFlag = false;
            ReticleBehaviour.doAnim = false;
            UIPanelBehaviour.Show = false;
        }
    }

}
