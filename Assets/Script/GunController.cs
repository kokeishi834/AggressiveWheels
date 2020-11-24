using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GunController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    handleclass HANDLE_INPUT;

    public int damage = 10;
    public int late = 10;

    int shot_late = 0;

    void Start()
    {
        HANDLE_INPUT = this.GetComponent<handleclass>();
        //修正する箇所
        //transform.parent = transform.GetChild(1).gameObject.transform;
        transform.position = GameObject.Find("shooter").transform.position;
        transform.parent = GameObject.Find("shooter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        HANDLE_INPUT.UpdateJoyPad();

        //Xキーで発射
        if (Input.GetKey(KeyCode.X) || HANDLE_INPUT.Button(handleclass.Buttons.ShiftDown) || HANDLE_INPUT.Button(handleclass.Buttons.ShiftUp))
        {
            if (shot_late % late == 0)
            {
                //弾の呼び出し
                GameObject bullet = GameObject.Find("BulletGenerator");
                bullet.GetComponent<BulletController>().Shoot(
                    this.transform.position,
                    this.transform.rotation.eulerAngles, this.gameObject,
                    10000,
                    damage);
            }
            shot_late++;
        }
        else
        {
           shot_late = 0;
        }
    }
}
