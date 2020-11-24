using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lookOnPlayer : MonoBehaviour
{
    public Image scoop;//ロックオンマーカー
    public GameObject gun;//銃座

    public string playerTag = "Player";
    public string cpuTag = "Enemy";
    private GameObject nearObj = null;         //最も近いオブジェクト
    private float searchTime = 0;       //経過時間

    int type = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を取得
        searchTime += Time.deltaTime;

        Debug.Log(type);

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
        //scoop.GetComponent<Image>().sprite = Resources.Load<Sprite>("rook");

        if ((other.tag == playerTag) || (other.tag == cpuTag))
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, other.tag);
            //this.transform.LookAt(nearObj.transform);
            Debug.Log("a");
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    type *= -1;
            //}
            //if(type == -1)
            //{
            //    gun.transform.LookAt(nearObj.transform);
            //}

            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("q");

                //scoop.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("rook2");
                gun.transform.LookAt(nearObj.transform);
            }
        }
        
    }


}
