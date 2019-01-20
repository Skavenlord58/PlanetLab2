using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    float acc = .0f;
    public static float speedmult = .0f;
    public Camera me;

	void Start () {
        me = GetComponent<Camera>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        acc = Input.GetAxis("Vertical");   
        me.fieldOfView = 60.0f + 10.0f * (acc * speedmult);       
    }
}
