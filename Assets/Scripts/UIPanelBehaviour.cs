using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelBehaviour : MonoBehaviour {

    Image img;
    public static bool Show = false;

	void Start ()
    {
        img = GetComponent<Image>();
	}
	

	void FixedUpdate () {
		if(Show)
        {
            img.enabled = true;
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);
        }
        else
        {
            img.enabled = false;
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
        }
	}
}
