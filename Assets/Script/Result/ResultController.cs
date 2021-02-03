using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultController : MonoBehaviour
{
    int result_score = 0;
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    public void SetResultScore(int score)
    {
        result_score = score;
    }
   
    public int GetResultScore()
    {
       return result_score;
    }

    //一人用で一時的に使う時間取得の関数、後に削除
    public void SetResultTime(int count)
    {
        time = count;
    }

    //一人用で一時的に使う時間取得の関数、後に削除
    public int SetResultTime()
    {
        return time;
    }
}
