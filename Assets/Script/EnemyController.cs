using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyController : MonoBehaviourPunCallbacks
{

    public int maxHp = 50;
    int hp;
    private Vector3 startPos;
    bool deadObject;
    int point;//倒された時の得点
    public void initialize()
    {
        this.gameObject.SetActive(true);
        deadObject = false;
        hp = maxHp;
        point = 20;
        transform.position = startPos;
        gameObject.GetComponent<NavMeshTest>().Start();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            DestroyObject();
        }
        if(deadObject)
        {
            this.gameObject.SetActive(false);
        }
    }

    void DestroyObject()
    {
        //爆発エフェクトの呼び出し
        GameObject burst_spark = GameObject.Find("eff_burst_spark");
        burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
        this.deadObject = true;        
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
