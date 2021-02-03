using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPointDisplay : MonoBehaviour
{
    GameObject result_point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        result_point = GameObject.Find("ResultManager");
        Text point_text = gameObject.GetComponent<Text>();
        //int をstringに変換する
        string point_string = result_point.GetComponent<ResultController>().GetResultScore().ToString();//object_point.ToString();
        // テキストの表示を入れ替える
        point_text.text = "Point・・・" + point_string;
    }
}
