using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandleC;

public class ht : MonoBehaviour
{
    public int player = 0;
    HC handle;
    // Start is called before the first frame update
    void Start()
    {
        handle = new HC();
    }

    // Update is called once per frame
    void Update()
    {
        handle.UpdateJoyPad(player);
        this.gameObject.transform.position = new Vector3(handle.LimitHandle(player) * 5,0,0);
        Debug.Log((player+1)+"P = " + handle.LimitHandle(player));
        if (handle.KeepButton(HC.Buttons.X, player)) { Debug.Log((player+1)+"P = X"); }
    }
}
