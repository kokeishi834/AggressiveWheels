﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public int timer = 180;//消滅までの時間
    public int power = 20;//弾の威力
    GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    //当たったら爆発して消滅
    void OnTriggerEnter(Collider other)
    {
        if (owner.tag == "Player" && (other.tag == "Enemy"))// || other.tag == "Player2"))
        {
            //爆発エフェクトの呼び出し
            GameObject burst_spark = GameObject.Find("eff_burst_spark_red");
            burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
            //弾を消す
            Destroy(gameObject);
            //敵にダメージを与える
            other.GetComponent<EnemyController>().Damage(power, owner);
        }

        if (owner.tag == "Enemy" && other.tag == "Player")// || other.tag == "Player2"))
        {
            //爆発エフェクトの呼び出し
            GameObject burst_spark = GameObject.Find("eff_burst_spark_blue");
            burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
            //弾を消す
            Destroy(gameObject);
            //Playerにダメージを与える
            other.GetComponent<CarSecond>().PlayerDamage(power, owner);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (owner.tag == "Player" && other.collider.tag == "Enemy")// || other.tag == "Player2"))
        {
            //爆発エフェクトの呼び出し
            GameObject burst_spark = GameObject.Find("eff_burst_spark_red");
            burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
            //弾を消す
            Destroy(gameObject);
            //敵にダメージを与える
            other.gameObject.GetComponent<EnemyController>().Damage(power, owner);
        }

        if (owner.tag == "Enemy" && other.collider.tag == "Player")// || other.tag == "Player2"))
        {
            //爆発エフェクトの呼び出し
            GameObject burst_spark = GameObject.Find("eff_burst_spark_blue");
            burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
            //弾を消す
            Destroy(gameObject);
            //Playerにダメージを与える
            other.gameObject.GetComponent<CarSecond>().PlayerDamage(power, owner);
        }
    }

    //所有権を渡す関数
    public void GetOwner(GameObject owner_gameobject,int damage)
    {
        owner = owner_gameobject;
        power = damage;
    }
}
