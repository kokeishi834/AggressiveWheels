using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockOn : MonoBehaviour
{
    GameObject pearents;
    public GameObject[] Guns = null;

    bool look_enemy = false;
    // Start is called before the first frame update
    void Start()
    {
        pearents = gameObject.transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!look_enemy)
        {
            foreach (GameObject obj in Guns)
            {
                obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        look_enemy = false;
    }

    void OnTriggerStay(Collider other)
    {
        look_enemy = true;
        if(other.tag == "Enemy")
        {
            GameObject near_object = serchTag(pearents,"Enemy");
            foreach(GameObject obj in Guns)
            {
                obj.transform.LookAt(near_object.transform);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            foreach (GameObject obj in Guns)
            {
                obj.transform.localRotation = Quaternion.Euler(0,0,0);
            }
        }
    }

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
}
