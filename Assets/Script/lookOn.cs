using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookOn : MonoBehaviour
{
    public string Tag1 = "Player";
    public string Tag2 = "CPU";
    public float interval = 1.0f;
    public float blurry = 8.0f;
    public float bulletSpeed = 1.0f;
    public int damage = 10;
    private GameObject nearObj = null;         //最も近いオブジェクト
    private float searchTime = 0;              //経過時間
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject.transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を取得
        searchTime += Time.deltaTime;
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }

    void OnTriggerStay(Collider other)
    {
        if((other.tag == Tag1) || (other.tag == Tag2))
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, other.tag);
            //parent.transform.LookAt(new Vector3(nearObj.transform.position.x,parent.transform.position.y,nearObj.transform.position.z));
            this.transform.LookAt(nearObj.transform);
            if (searchTime >= interval)
            {
                //経過時間を初期化
                searchTime = 0;
                //弾の呼び出し
                GameObject bullet = GameObject.Find("BulletGenerator");
                bullet.GetComponent<BulletController>().Shoot(this.transform.position,
                new Vector3(this.transform.rotation.eulerAngles.x + Random.Range(-blurry,blurry),
                            this.transform.rotation.eulerAngles.y + Random.Range(-blurry, blurry),
                            this.transform.rotation.eulerAngles.z + Random.Range(-blurry, blurry)),
                            parent,bulletSpeed, damage);
            }
        }
    }
}
