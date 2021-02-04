using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointDisplay : MonoBehaviour
{
    public GameObject player = null;
    public GameObject Point = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text point_text = Point.GetComponent<Text>();
        //int をstringに変換する
        string point_string = player.GetComponent<PointController>().now_point.ToString();
        // テキストの表示を入れ替える
        point_text.text = "Point・・・" + point_string;
    }
}
