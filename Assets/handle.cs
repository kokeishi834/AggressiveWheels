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
        handle.UpdateJoyPad();

        handle.LimitHandle();
        Debug.Log(handle.LimitHandle());
        handle.Pedal(HC.Pedals.accelerator);
        Debug.Log(handle.Pedal(HC.Pedals.accelerator));
        handle.Pedal(HC.Pedals.brake);
        Debug.Log(handle.Pedal(HC.Pedals.brake));
        if (handle.ButtonDown(HC.Buttons.A)) { Debug.Log("A"); }

        if (handle.Button(HC.Buttons.B)) { Debug.Log("B"); }

        if (handle.KeepButton(HC.Buttons.C)) { Debug.Log("C"); }

        if (handle.KeepButton(HC.Buttons.X)) { Debug.Log("X"); }

        if (handle.KeepButton(HC.Buttons.Y)) { Debug.Log("Y"); }

        if (handle.KeepButton(HC.Buttons.Z)) { Debug.Log("Z"); }

        if (handle.KeepButton(HC.Buttons.ShiftDown)) { Debug.Log("ShiftDown"); }

        if (handle.KeepButton(HC.Buttons.ShiftUp)) { Debug.Log("ShiftUp"); }



    }
}
