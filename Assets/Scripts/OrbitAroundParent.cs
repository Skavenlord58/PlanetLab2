using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundParent : MonoBehaviour {

    public Transform target;    // the object to orbit around
    public int rotSpd;   // the speed of rotation

    void Start()
    {
        if (target == null)
        {
            target = this.gameObject.transform;
            Debug.Log("Orbit target not specified. Defaulting to parenting object.");
        }
    }

    void FixedUpdate()
    {
        while (!PlayerMovement.freeze)
            transform.RotateAround(target.transform.position, target.transform.up, rotSpd * Time.deltaTime);
    }
}
