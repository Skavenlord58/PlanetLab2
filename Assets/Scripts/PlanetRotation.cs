using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour {

    public float rotSpd = 30.0f;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        while (!PlayerMovement.freeze)
            transform.Rotate(0, rotSpd * Time.deltaTime, 0);
    }
}
