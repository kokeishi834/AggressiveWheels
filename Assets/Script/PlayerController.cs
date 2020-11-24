using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DxLibDLL;

public class PlayerController : MonoBehaviour
{
    public int player_hp = 0;
    int max_hp;//初期体力を入れておく変数
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0.5f;
        max_hp = player_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
        // 左に回転
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, angle * -4.0f, 0.0f));
        }
        // 右に回転
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, angle * 4.0f, 0.0f));
        }
        // 前に移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, 0.0f, 1.5f);
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.0f, 0.0f, -0.5f);
        }

        //Zキーで爆発
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //爆発エフェクトの呼び出し
            GameObject burst_spark = GameObject.Find("eff_burst_spark");
            burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);  
        }

        //Xキーで発射
        if (Input.GetKeyDown(KeyCode.X))
        {
            //弾の呼び出し
            GameObject bullet = GameObject.Find("BulletGenerator");
            bullet.GetComponent<BulletController>().Shoot(
                this.transform.position,
                this.transform.rotation.eulerAngles, this.gameObject,
                10000,
                5);
        }

        //hpが0になったらポイント半減（変える部分）
        if (player_hp <= 0)
        {
            this.GetComponent<PointController>().DeathPoint();
            player_hp = max_hp;
        }
        
    }

    //エネミーと当たった時
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //体力減少
            player_hp -= 30;
            //爆発エフェクトの呼び出し
            GameObject burst_spark = GameObject.Find("eff_burst_spark");
            burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
        }
    }

}
