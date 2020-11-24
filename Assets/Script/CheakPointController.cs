using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CheakPointController : MonoBehaviourPunCallbacks
{
    int point;//チェックポイントの得点
    // Start is called before the first frame update
    void Start()
    {
        point = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ここにチェックポイント到達時の処理を書く
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //ポイントを渡して消滅
            other.gameObject.GetComponent<PointController>().PlusPoint(point);
            Destroy(this.gameObject);
        }
    }
}
