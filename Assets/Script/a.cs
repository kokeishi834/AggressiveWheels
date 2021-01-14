using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class a : MonoBehaviour
{
    //エネミーに付ける
    //public Image scoop;//ロックオンマーカー

    public GameObject gun = null;//銃
    public Transform player_camera = null;//カメラ
    int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 11;//障害物のレイヤーを作って、1 << その番号 にする
        gun = GameObject.FindWithTag("Player").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        player_camera = GameObject.FindWithTag("Player").transform.GetChild(3).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gun == null)
        {
            gun = GameObject.FindWithTag("Player").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        }
        if(player_camera == null)
        {
            player_camera = GameObject.FindWithTag("Player").transform.GetChild(3).transform;
        }
    }

    // Disable the behaviour when it becomes invisible...
    //void OnBecameInvisible()
    //{
    //    Debug.Log("a3");
    //}

    // ...and enable it again when it becomes visible.
    //void OnBecameVisible()
    //{
    //    Debug.Log("a2");
    //}

    void OnWillRenderObject()
    {
        //scoop.GetComponent<Image>().sprite = Resources.Load<Sprite>("rook");

        if(Camera.current.tag == "PlayerCamera")
        {
            if (Physics.Linecast(transform.position, player_camera.position, layerMask))
            {
                Debug.Log("blocked");
                //scoop.GetComponent<Image>().sprite = Resources.Load<Sprite>("none_null");
            }
            else
            {
                Debug.Log("lock");
                gun.transform.LookAt(transform);
            }
        }

        //Debug.Log(Camera.current.name);
    }
}