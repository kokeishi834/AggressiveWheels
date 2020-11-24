using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c : MonoBehaviour
{
    public GameObject target;
    private Vector3 distance;
    //private Quaternion rot;

    void Start()
    {
        //distance = transform.position - target.transform.position;
        distance = target.transform.position;
    }

    void Update()
    {
        transform.position += target.transform.position - distance;
        //transform.rotation = target.transform.rotation;
        distance = target.transform.position;

        //transform.rotation = rot;
        
        distance = target.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(target.transform.position, Vector3.up, -1.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(target.transform.position, Vector3.up, 1.0f);
        }
    }
}