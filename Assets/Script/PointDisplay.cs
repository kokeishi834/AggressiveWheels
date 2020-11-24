using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class PointDisplay : MonoBehaviour
{
    public GameObject player = null;
    public GameObject Point = null;
    int count;//一人用に一時的にポイントをタイムで表示、後で削除
    // Start is called before the first frame update
    void Start()
    {
        count = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        int now_time = count / 60;
        Text point_text = Point.GetComponent<Text>();
        //int をstringに変換する
        string point_string = player.GetComponent<PointController>().now_point.ToString();
        // テキストの表示を入れ替える
        point_text.text = "Time・・・" + now_time.ToString();// "Point・・・" + point_string;
    }
}
