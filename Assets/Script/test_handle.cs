﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandleC;

public class test_handle : MonoBehaviour
{
    HC handle;
    // Start is called before the first frame update
    void Start()
    {
        handle = new HC();
    }

    // Update is called once per frame
    void Update()
    {
        handle.UpdateJoyPad();
        Debug.Log("1P = " + handle.LimitHandle(0));
        Debug.Log("2P = " + handle.LimitHandle(1));
        if (handle.KeepButton(HC.Buttons.X, 0)) { Debug.Log("1P = X"); }

        if (handle.KeepButton(HC.Buttons.X, 1)) { Debug.Log("2P = X"); }
    }
}
