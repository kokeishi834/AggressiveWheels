using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class buttonfunction : MonoBehaviour
{
    // Start is called before the first frame update
    int car_num;
    int parts_num;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StringArgFunction(string s)
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        SceneManager.LoadScene(s);
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {

        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("GamePlayManager").GetComponent<GamePlayManager>();

        // データを渡す処理
        gameManager.SetPlayerInfo(car_num, parts_num);

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    public void SetCustomNum(int car,int parts)
    {
        car_num = car;
        parts_num = parts;
    }
}
