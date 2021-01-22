using System.Collections;
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
        // 入力状態を取得
        handle.UpdateJoyPad(0);

        this.transform.Translate(0.2f * handle.LimitHandle(0), 0, 0);
    }
}
