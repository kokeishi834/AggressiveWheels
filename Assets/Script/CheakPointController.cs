using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheakPointController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            GameObject manager = GameObject.Find("CheckPlayManager");
            manager.GetComponent<CheckPlayManager>().Pass_Check();
            this.gameObject.SetActive(false);
        }
    }
}
