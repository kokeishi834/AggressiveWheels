using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class HpDisplay : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public GameObject HP; // Textオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.Find("Player");//object_name
        Text hp_text = HP.GetComponent<Text>();
        //int をstringに変換する
        string hp_string = player.GetComponent<CarSecond>().player_hp.ToString();//object_point.ToString();
        //Debug.Log("HP" + hp_string);
        // テキストの表示を入れ替える
        hp_text.text = hp_string;
    }
}
