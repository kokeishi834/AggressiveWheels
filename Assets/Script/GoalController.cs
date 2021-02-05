using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    int point;
    int time = 0;//一人用で一時的に使う時間
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//ゴールの描画と判定を消す    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject point_object = GameObject.FindGameObjectWithTag("Player");

        point = point_object.GetComponent<PointController>().GetPoint();

        time++;
    }

    //ゴールでリザルト画面へ移行（後々修正する箇所、全員がゴールした時に変更する）
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject score = GameObject.FindWithTag("Score");
            time = score.GetComponent<TimeDisplay>().GetTime();
            // イベントに登録
            SceneManager.sceneLoaded += GameSceneLoaded;

            SceneManager.LoadScene("ResultScene");
        }
    }

    //シーン遷移時にポイントを渡す関数（要調整）
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {

        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("ResultManager").GetComponent<ResultController>();


        //GameObject point_object = GameObject.Find("Player");

        //int point = point_object.GetComponent<PointController>().GetPoint();

        // データを渡す処理
        gameManager.SetResultScore(point + (60 - time));
        gameManager.SetResultTime(time);

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    //一人用で一時的に使う時間取得関数、後に修正or削除
    public void SetCount(int count)
    {
        time += count;
        //.Log(count);
        //Debug.Log(time);
    }
}
