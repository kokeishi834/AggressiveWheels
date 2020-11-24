using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyController : MonoBehaviourPunCallbacks
{
    public int hp = 50;
    int point;//倒された時の得点
    // Start is called before the first frame update
    void Start()
    {
        point = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {
        //爆発エフェクトの呼び出し
        GameObject burst_spark = GameObject.Find("eff_burst_spark");
        burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
        Destroy(this.gameObject);
    }

    //ダメージの関数、体力が０で消滅
    public void Damage(int damage,GameObject owner)
    {
        hp -= damage;
        if(hp <= 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            player.GetComponent<PointController>().PlusPoint(point);

            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GamePlayManager>().KillEnemy();
           // owner.GetComponent<PointController>().PlusPoint(point);
            DestroyObject();
        }
    }
}
