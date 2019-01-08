using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Speedometer : MonoBehaviour {

    public Rigidbody player;
    Text content;
	
    void Start()
    {
        content = GetComponent<Text>();
    }

	void FixedUpdate () {
        content.text = Convert.ToString(Convert.ToInt32(player.velocity.magnitude));
	}
}
