using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleBehaviour : MonoBehaviour {

    Image img;
    public Material ret_static;
    public Material ret_1;
    public Material ret_2;
    public Material ret_3;
    public Material ret_4;
    public Material ret_5;
    public Material ret_6;
    public Material ret_7;
    public Material ret_8;
    // ^^^^ tohle je abych si mohl naházet materiály přímo z Unity Inspectora
    // toto je zase kolekce těch materiálů, ať se na ně líp přistupuje v cyklu
    List<Material> ret_anim = new List<Material>();

    float targettime = 0.2f;

    //momentálně debug var, pak si budu frames počítat globálně na všechny tyhle stuffy
    int current_state = 1;

    void Start () {
        //nacpání materiálů do listu, kvůli přehlednosti
        ret_anim.Add(ret_static);
        ret_anim.Add(ret_1);
        ret_anim.Add(ret_2);
        ret_anim.Add(ret_3);
        ret_anim.Add(ret_4);
        ret_anim.Add(ret_5);
        ret_anim.Add(ret_6);
        ret_anim.Add(ret_7);
        ret_anim.Add(ret_8);

        img = GetComponent<Image>();
            }
	
    void NextStep()
    {
        img.material = ret_anim[current_state];
        current_state++;

        if (current_state == 9)
            current_state = 0;
    }

    bool doAnim = false;
    void doAnimation()
    {
        targettime -= Time.deltaTime;

        if (targettime <= 0.0f)
        {
            NextStep();
            targettime = 0.20f;
        }
    }

	void FixedUpdate () {

        //zatím to nebudu hrotit a nasázel jsem to na tlačítko
        doAnim = Input.GetButton("Fire1");
        if (doAnim)
        {
            doAnimation();
        }
        else
        {
            current_state = 1;
            img.material = ret_anim[0];
        }
        
	}
}
