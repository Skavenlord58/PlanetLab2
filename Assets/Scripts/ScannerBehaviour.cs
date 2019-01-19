using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ScannerBehaviour : MonoBehaviour {

    static List<string> PlanetNames = new List<string>();
    static List<string[]> PlanetInfo = new List<string[]>();

    public static Text Name;
    public static Text Area;
    public static Text Radius;
    public static Text Mass;
    public static Text Density;
    public static Text Atmosphere;
    public static Text SIHFE;

    static int PlanetIndex = 0;

    void InitDB()
    {

        PlanetInfo.Insert(0, new string[7]{ "Unknown" , "Area: ???" , "Radius: ???",
            "Mass: ???", "Density:\n???", "Atmosphere:\n ???","Rate of\n Si/H/Fe: ???" });

        PlanetInfo.Insert(1, new string[7]{ "Sun" , "Area: ???" , "Radius: ???",
            "Mass: ???", "Density:\n???", "Atmosphere:\n ???","Rate of\n Si/H/Fe: ???" });

        PlanetInfo.Insert(2, new string[7]{ "Mercury" , "Area: ???" , "Radius: 2439.7 km",
            "Mass: ???", "Density:\n5.427 g/cm2", "Atmosphere:\n 0 kPa","Rate of\n Si/H/Fe: 54/0/46" });

        PlanetInfo.Insert(3, new string[7]{ "Venus" , "Area: ???" , "Radius: 6051.8 km",
            "Mass: ???", "Density:\n5.204 g/cm2", "Atmosphere:\n 9 321 kPa","Rate of\n Si/H/Fe: 80/0/20" });

        PlanetInfo.Insert(4, new string[7]{ "Earth" , "Area: ???" , "Radius: 6378 km",
            "Mass: ???", "Density:\n5.515 g/cm2", "Atmosphere:\n 100 kPa","Rate of\n Si/H/Fe: 75/1/24" });

        PlanetInfo.Insert(5, new string[7]{ "Mars" , "Area: ???" , "Radius: 3396.2 km",
            "Mass: ???", "Density:\n3.933 g/cm2", "Atmosphere:\n 0.9 kPa","Rate of\n Si/H/Fe: 90/<1/10" });

        PlanetInfo.Insert(6, new string[7]{ "Jupiter" , "Area: ???" , "Radius: 71 492 km",
            "Mass: ???", "Density:\n1.326 g/cm2", "Atmosphere:\n 110 kPa","Rate of\n Si/H/Fe: 2/98/0" });

        PlanetInfo.Insert(7, new string[7]{ "Saturn" , "Area: ???" , "Radius: 60 268 km",
            "Mass: ???", "Density:\n0.6873 g/cm2", "Atmosphere:\n 140 kPa","Rate of\n Si/H/Fe: 2/98/0" });

        PlanetInfo.Insert(8, new string[7]{ "Uranus" , "Area: ???" , "Radius: 25 559 km",
            "Mass: ???", "Density:\n1.270 g/cm2", "Atmosphere:\n 120 kPa","Rate of\n Si/H/Fe: 2/98/0" });

        PlanetInfo.Insert(9, new string[7]{ "Neptune" , "Area: ???" , "Radius: 24 764 km",
            "Mass: ???", "Density:\n1.638 g/cm2", "Atmosphere:\n >>100 kPa","Rate of\n Si/H/Fe: 14/81/5" });

        PlanetInfo.Insert(10, new string[7]{ "Pluto" , "Area: ???" , "Radius: ???",
            "Mass: ???", "Density:\n???", "Atmosphere:\n ???","Rate of\n Si/H/Fe: ???" });

        PlanetInfo.Insert(11, new string[7]{ "Moon" , "Area: ???" , "Radius: ???",
            "Mass: ???", "Density:\n???", "Atmosphere:\n ???","Rate of\n Si/H/Fe: ???" });
    }

    public void Start()
    {
        Name = transform.Find("Name").GetComponentInChildren<Text>();
        Area = transform.Find("Area").GetComponentInChildren<Text>();
        Radius = transform.Find("Rads").GetComponentInChildren<Text>();
        Mass = transform.Find("Mass").GetComponentInChildren<Text>();
        Density = transform.Find("Dens").GetComponentInChildren<Text>();
        Atmosphere = transform.Find("Atmo").GetComponentInChildren<Text>();
        SIHFE = transform.Find("SIHFE").GetComponentInChildren<Text>();

        InitDB();
    }

    public static void GetPlanetInfo(string planet)
    {
        if (!string.IsNullOrEmpty(PlanetNames.Find(x => x == planet)))
        {

            switch (planet)
            {
                case "Sun":
                    PlanetIndex = 1;
                    break;
                case "Mercury":
                    PlanetIndex = 2;
                    break;
                case "Venus":
                    PlanetIndex = 3;
                    break;
                case "Earth":
                    PlanetIndex = 4;
                    break;
                case "Mars":
                    PlanetIndex = 5;
                    break;
                case "Jupiter":
                    PlanetIndex = 6;
                    break;
                case "Saturn":
                    PlanetIndex = 7;
                    break;
                case "Uranus":
                    PlanetIndex = 8;
                    break;
                case "Neptune":
                    PlanetIndex = 9;
                    break;
                case "Pluto":
                    PlanetIndex = 10;
                    break;
                case "Moon":
                    PlanetIndex = 11;
                    break;
                default:
                    PlanetIndex = 0;
                    break;
            }

            try
            {
                Name.text = PlanetInfo[PlanetIndex][0];
                Area.text = PlanetInfo[PlanetIndex][1];
                Radius.text = PlanetInfo[PlanetIndex][2];
                Mass.text = PlanetInfo[PlanetIndex][3];
                Density.text = PlanetInfo[PlanetIndex][4];
                Atmosphere.text = PlanetInfo[PlanetIndex][5];
                SIHFE.text = PlanetInfo[PlanetIndex][6];
            }
            catch(Exception)
            {
                Name.text = PlanetInfo[0][0];
                Area.text = PlanetInfo[0][1];
                Radius.text = PlanetInfo[0][2];
                Mass.text = PlanetInfo[0][3];
                Density.text = PlanetInfo[0][4];
                Atmosphere.text = PlanetInfo[0][5];
                SIHFE.text = PlanetInfo[0][6];
            }
            
        }
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
                //Debug.Log("Planet " + parse + " added to the log!");
            }
        }
        else
        {
            GetPlanetInfo(parse);
            UIPanelBehaviour.Show = true;
        }
    }
}
