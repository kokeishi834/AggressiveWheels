using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HandleC;
public class ResultController : MonoBehaviour
{
    int result_score = 0;
    int time = 0;
    HC HANDLE_INPUT = new HC();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HANDLE_INPUT.UpdateJoyPad(0);

        if (Input.GetKeyDown(KeyCode.Space) ||
           HANDLE_INPUT.Button(HC.Buttons.A, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.B, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.C, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.X, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.Y, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.Z, 0)
           )
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
    public int GetResultTime()
    {
        return time;
    }
}
