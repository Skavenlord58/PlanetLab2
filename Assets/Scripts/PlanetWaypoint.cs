using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlanetWaypoint : MonoBehaviour
{

    public GameObject Planet;
    public Transform playerLoc;

    Vector3 planetLoc;

    Color customColor = new Color(1f, 0.549f, 0, 0.9f); 
    // Color darkcyan = new Color(0, 0.408f, 0.545f, 0.9f);
    GUIStyle marker = new GUIStyle();
    public Font markerfont;


    void Start()
    {
        Planet = this.gameObject;
        marker.font = markerfont;
        marker.fontSize = 32;
        marker.normal.textColor = customColor;

    }

    void LateUpdate()
    {
          planetLoc = Camera.main.WorldToScreenPoint(Planet.transform.position);
    }

    void OnGUI()
    {
        marker.normal.textColor = customColor;
        GUI.contentColor = customColor;
        if (planetLoc.z > 0)
        {
            GUI.Label(new Rect(planetLoc.x + 6, Screen.height - planetLoc.y, 100, 20), Planet.name, marker);
            GUI.Label(new Rect(planetLoc.x - 6, Screen.height - planetLoc.y, 100, 20), "▲");
        }
    }
    
}

