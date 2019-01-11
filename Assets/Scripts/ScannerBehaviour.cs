using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScannerBehaviour : MonoBehaviour {

    static List<string> PlanetNames = new List<string>();

    public static void GetPlanetInfo(string planet)
    {

    }

    public static void Scan(string name)
    {
        string parse = name;
        PlanetNames.Add("null");

        if (string.IsNullOrEmpty(PlanetNames.Find(x => x == parse)))
        {
            ReticleBehaviour.doAnim = true;
            if (ReticleBehaviour.current_state == 9)
            {
                ReticleBehaviour.doAnim = false;
                PlanetNames.Add(parse);
                Debug.Log("Planet " + parse + " added to the log!");
            }
        }
        else
        {
            GetPlanetInfo(parse);
            UIPanelBehaviour.Show = true;
        }
    }
}
