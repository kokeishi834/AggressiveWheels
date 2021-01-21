using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandleC;

public class handle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HC handle = new HC();
        // 入力状態を取得
        handle.UpdateJoyPad(0);

        handle.LimitHandle(0);
        Debug.Log(handle.LimitHandle(0));
        handle.Pedal(HC.Pedals.accelerator,0);
        Debug.Log(handle.Pedal(HC.Pedals.accelerator,0));
        handle.Pedal(HC.Pedals.brake,0);
        Debug.Log(handle.Pedal(HC.Pedals.brake,0));
        if (handle.Button(HC.Buttons.B,0)) { Debug.Log("B"); }

        if (handle.KeepButton(HC.Buttons.C, 0)) { Debug.Log("C"); }

        if (handle.KeepButton(HC.Buttons.X, 0)) { Debug.Log("X"); }

        if (handle.KeepButton(HC.Buttons.Y, 0)) { Debug.Log("Y"); }

        if (handle.KeepButton(HC.Buttons.Z, 0)) { Debug.Log("Z"); }

        if (handle.KeepButton(HC.Buttons.ShiftDown, 0)) { Debug.Log("ShiftDown"); }

        if (handle.KeepButton(HC.Buttons.ShiftUp, 0)) { Debug.Log("ShiftUp"); }



    }
}
