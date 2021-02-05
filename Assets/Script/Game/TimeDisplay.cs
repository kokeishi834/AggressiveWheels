using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeDisplay : MonoBehaviour
{
    public GameObject Time = null;
    int count;//カウント
    int now_time;//時間
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        now_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        now_time = count / 60;
        Text time_text = Time.GetComponent<Text>();
        // テキストの表示を入れ替える
        time_text.text = "Time・・・" + now_time.ToString();
    }

    public int GetTime()
    {
        return now_time;
    }
}
