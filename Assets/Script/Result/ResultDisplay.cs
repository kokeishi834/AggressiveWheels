using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultDisplay : MonoBehaviour
{
    GameObject result;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        result = GameObject.Find("ResultManager");
        Text result_text = gameObject.GetComponent<Text>();
        if (result.GetComponent<ResultController>().GetResultScore() > 0)
        {
            //int をstringに変換する
            string point_string = result.GetComponent<ResultController>().GetResultScore().ToString();
            result_text.text = "Point・・・" + point_string;
        }
        else
        {
            //int をstringに変換する
            int time = result.GetComponent<ResultController>().GetResultTime();
            string time_string = time.ToString();
            // テキストの表示を入れ替える
            result_text.text = "Time・・・" + time_string;
        }
    }
}
