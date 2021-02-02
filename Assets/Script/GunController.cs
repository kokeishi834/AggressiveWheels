using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandleC;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    public int player_num = 0;
    HC HANDLE_INPUT = new HC();

    public int damage = 10;
    public int late = 10;

    int shot_late = 0;

    void Start()
    {
        //HANDLE_INPUT = this.GetComponent<HC>();
        //修正する箇所
        //transform.parent = transform.GetChild(1).gameObject.transform;
        transform.position = GameObject.Find("shooter").transform.position;
        transform.parent = GameObject.Find("shooter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        HANDLE_INPUT.UpdateJoyPad(player_num);

        //Xキーで発射
        if (Input.GetKey(KeyCode.X) || HANDLE_INPUT.Button(HC.Buttons.ShiftDown,player_num) || HANDLE_INPUT.Button(HC.Buttons.ShiftUp,player_num))
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
