using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultTimeDisplay : MonoBehaviour
{
    GameObject result_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        result_time = GameObject.Find("ResultManager");
        Text time_text = gameObject.GetComponent<Text>();
        //int をstringに変換する
        int time = result_time.GetComponent<ResultController>().SetResultTime() / 60;
        string time_string = time.ToString();
        // テキストの表示を入れ替える
        time_text.text = "Time・・・" + time_string;
    }
}
